
using System.Runtime.InteropServices;


// ------------------


[DllImport("User32.dll", CharSet=CharSet.Unicode)]
public static extern int MessageBox(IntPtr h, string m, string c, int type);


MessageBox(new IntPtr(), "Bora ficar ninja!", "Devmonk", 1);


// ------------------

