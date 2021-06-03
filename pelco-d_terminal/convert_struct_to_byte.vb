Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices

Module StructureExtensions

    ' <summary>
    ' Converts simple structure to byte-array
    ' </summary>
    ' <typeparam name="T"></typeparam>
    ' <param name="[structure]"></param>
    ' <returns></returns>
    <Extension()> _
    Public Function ToByteArray(Of T As Structure)(ByVal [structure] As T) As Byte()
        Dim bufferSize = Marshal.SizeOf([structure])
        Dim byteArray = New Byte(bufferSize - 1) {}
        Dim handle As IntPtr = Marshal.AllocHGlobal(bufferSize)
        Try
            Marshal.StructureToPtr([structure], handle, False)
            Marshal.Copy(handle, byteArray, 0, bufferSize)
        Finally
            Marshal.FreeHGlobal(handle)
        End Try

        Return byteArray
    End Function

    ' <summary>
    ' converts byte-array to simple structure
    ' </summary>
    ' <typeparam name="T"></typeparam>
    ' <param name="bytearray"></param>
    ' <returns></returns>
    <Extension()> _
    Public Function ToStructure(Of T As Structure)(ByVal bytearray As Byte()) As T
        Dim [structure] As New T
        Dim len As Integer = Marshal.SizeOf([structure])
        Dim i As IntPtr = Marshal.AllocHGlobal(len)
        Marshal.Copy(bytearray, 0, i, len)
        [structure] = Marshal.PtrToStructure(i, [structure].[GetType]())
        Marshal.FreeHGlobal(i)
        Return [structure]
    End Function

End Module