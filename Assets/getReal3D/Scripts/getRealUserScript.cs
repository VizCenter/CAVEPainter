using UnityEngine;
using System.Collections;

public class getRealUserScript : MonoBehaviour {

    private getRealUser m_getRealUser = null;
    
    public uint userId()
    {
        findGetRealUser();
        return m_getRealUser == null ? 0 : m_getRealUser.userId;
    }

    public getRealUser user()
    {
        findGetRealUser();
        return m_getRealUser;
    }

    public getReal3D.Sensor getHead()
    {
        return getReal3D.Input.headForUser(userId());
    }

    public getReal3D.Sensor getWand()
    {
        return getReal3D.Input.wandForUser(userId());
    }

    private void findGetRealUser()
    {
        if (m_getRealUser) { return; }
        m_getRealUser = GetComponentInParent<getRealUser>();
    }
}
