using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SessionLayer
{
  public class SessionManager
  {
    //singleton için locklama nesnesi
    private static object s_LockObj = new Object();
    //singleton için static instance
    private static SessionManager instance = null;

    #region Singleton

    public static SessionManager Instance()
    {
      if (instance == null)
      {
        lock (s_LockObj)
        {
          if (instance == null)
          {
            instance = new SessionManager();
          }
        }
      }
      return instance;
    }

    private SessionManager()
    {

    }
    #endregion


    protected Hashtable storage = new Hashtable();

    public T GetValue<T>(string key)
    {
      if (HttpContext.Current != null)
      {
        if (HttpContext.Current.Session != null)
        {
          if (HttpContext.Current.Session[key] != null)
            return (T)HttpContext.Current.Session[key];
          else return default(T);
        }
      }

      if (storage.Contains(key))
        return (T)storage[key];
      else return default(T);
    }

    public void SetValue<T>(string key, object value)
    {
      if (HttpContext.Current != null)
      {
        if (HttpContext.Current.Session != null)
        {
          HttpContext.Current.Session[key] = value;
        }
      }
      storage[key] = value;
    }


    public void Abandon()
    {
      HttpContext.Current.Session.Clear();
      HttpContext.Current.Session.Abandon();
      storage.Clear();
    }

  }
}
