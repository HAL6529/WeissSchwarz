using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IPunObservable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        /* �I�[�i�[�̏ꍇ
        if (stream.IsWriting)
        {
            stream.SendNext(this._text);
        }
        // �I�[�i�[�ȊO�̏ꍇ
        else
        {
            this._text = (string)stream.ReceiveNext();
        }*/
    }
}
