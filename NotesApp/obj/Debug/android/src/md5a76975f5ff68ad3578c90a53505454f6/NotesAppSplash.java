package md5a76975f5ff68ad3578c90a53505454f6;


public class NotesAppSplash
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("NotesApp.NotesAppSplash, NotesApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", NotesAppSplash.class, __md_methods);
	}


	public NotesAppSplash () throws java.lang.Throwable
	{
		super ();
		if (getClass () == NotesAppSplash.class)
			mono.android.TypeManager.Activate ("NotesApp.NotesAppSplash, NotesApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
