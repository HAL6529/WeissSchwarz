using NUnit.Framework;
using System.Collections;
using Unity.Networking.Transport;
using Unity.Networking.Transport.Utilities;
using Unity.Netcode.Transports.UTP;
using UnityEngine;

using UTPNetworkEvent = Unity.Networking.Transport.NetworkEvent;
using static Unity.Netcode.RuntimeTests.UnityTransportTestHelpers;

namespace Unity.Netcode.RuntimeTests
{
    // Thin wrapper around a UTP NetworkDriver that can act as a client to a UnityTransport server.
    // In particular that means the pipelines are set up the same way as in UnityTransport.
    //
    // The only reason it's defined as a MonoBehaviour is that OnDestroy is the only reliable way
    // to get the driver's Dispose method called from a UnityTest. Making it disposable would be
    // the preferred solution, but that doesn't always mesh well with coroutines.
    public class UnityTransportDriverClient : MonoBehaviour
    {
        private NetworkDriver m_Driver;
        public NetworkDriver Driver => m_Driver;

        private NetworkConnection m_Connection;

        private NetworkPipeline m_UnreliableSequencedPipeline;
        private NetworkPipeline m_ReliableSequencedPipeline;
        private NetworkPipeline m_ReliableSequencedFragmentedPipeline;

        public NetworkPipeline UnreliableSequencedPipeline => m_UnreliableSequencedPipeline;
        public NetworkPipeline ReliableSequencedPipeline => m_ReliableSequencedPipeline;
        public NetworkPipeline ReliableSequencedFragmentedPipeline => m_ReliableSequencedFragmentedPipeline;

        private NetworkPipeline m_LastEventPipeline;
        public NetworkPipeline LastEventPipeline => m_LastEventPipeline;

        private void Awake()
        {
            var maxCap = UnityTransport.InitialMaxPayloadSize + 128;

            var settings = new NetworkSettings();
            settings.WithFragmentationStageParameters(payloadCapacity: maxCap);

            var fragParams = new FragmentationUtility.Parameters() { PayloadCapacity = maxCap };

            m_Driver = NetworkDriver.Create(settings);

            m_UnreliableSequencedPipeline = m_Driver.CreatePipeline(typeof(UnreliableSequencedPipelineStage));
            m_ReliableSequencedPipeline = m_Driver.CreatePipeline(typeof(ReliableSequencedPipelineStage));
            m_ReliableSequencedFragmentedPipeline = m_Driver.CreatePipeline(typeof(FragmentationPipelineStage), typeof(ReliableSequencedPipelineStage));
        }

        private void Update()
        {
            m_Driver.ScheduleUpdate().Complete();
        }

        private void OnDestroy()
        {
            if (m_Driver.IsCreated)
            {
                m_Driver.Dispose();
            }
        }

        public void Connect()
        {
            var endpoint = NetworkEndPoint.LoopbackIpv4;
            endpoint.Port = 7777;

            m_Connection = m_Driver.Connect(endpoint);
        }

        // Wait for the given event to be generated by the client's driver.
        public IEnumerator WaitForNetworkEvent(UTPNetworkEvent.Type type)
        {
            float startTime = Time.realtimeSinceStartup;

            while (Time.realtimeSinceStartup - startTime < MaxNetworkEventWaitTime)
            {
                UTPNetworkEvent.Type eventType = m_Driver.PopEvent(out _, out _, out m_LastEventPipeline);
                if (eventType != UTPNetworkEvent.Type.Empty)
                {
                    Assert.AreEqual(type, eventType);
                    yield break;
                }

                yield return null;
            }

            Assert.Fail("Timed out while waiting for network event.");
        }
    }
}