﻿'<snippet22>
Imports System.Runtime.InteropServices

'<snippet23>
' Declares a managed structure for each unmanaged structure.
<StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Ansi)>
Public Structure MyPerson
    Public first As String
    Public last As String
End Structure 'MyPerson

<StructLayout(LayoutKind.Sequential)>
Public Structure MyPerson2
    Public person As IntPtr
    Public age As Integer
End Structure 'MyPerson2

<StructLayout(LayoutKind.Sequential)>
Public Structure MyPerson3
    Public person As MyPerson
    Public age As Integer
End Structure 'MyPerson3

<StructLayout(LayoutKind.Sequential)>
Public Structure MyArrayStruct
    Public flag As Boolean
    <MarshalAs(UnmanagedType.ByValArray, SizeConst:=3)>
    Public vals As Integer()
End Structure 'MyArrayStruct

Public Class LibWrap
    ' Declares managed prototypes for unmanaged functions.
    <DllImport("..\LIB\PinvokeLib.dll", CallingConvention:=CallingConvention.Cdecl)>
    Shared Function TestStructInStruct(
        ByRef person2 As MyPerson2) As Integer
    End Function

    <DllImport("..\LIB\PinvokeLib.dll", CallingConvention:=CallingConvention.Cdecl)>
    Shared Function TestStructInStruct3(
        ByVal person3 As MyPerson3) As Integer
    End Function

    <DllImport("..\LIB\PinvokeLib.dll", CallingConvention:=CallingConvention.Cdecl)>
    Shared Function TestArrayInStruct(
        ByRef myStruct As MyArrayStruct) As Integer
    End Function
End Class 'LibWrap

'</snippet23>

'<snippet24>
Public Class App
    Public Shared Sub Main()
        ' Structure with a pointer to another structure.
        Dim personName As MyPerson
        personName.first = "Mark"
        personName.last = "Lee"

        Dim personAll As MyPerson2
        personAll.age = 30

        Dim buffer As IntPtr = Marshal.AllocCoTaskMem(Marshal.SizeOf(
            personName))
        Marshal.StructureToPtr(personName, buffer, False)

        personAll.person = buffer

        Console.WriteLine(ControlChars.CrLf & "Person before call:")
        Console.WriteLine("first = {0}, last = {1}, age = {2}",
            personName.first, personName.last, personAll.age)

        Dim res As Integer = LibWrap.TestStructInStruct(personAll)

        Dim personRes As MyPerson =
            CType(Marshal.PtrToStructure(personAll.person,
            GetType(MyPerson)), MyPerson)

        Marshal.FreeCoTaskMem(buffer)

        Console.WriteLine("Person after call:")
        Console.WriteLine("first = {0}, last = {1}, age = {2}",
        personRes.first,
            personRes.last, personAll.age)

        ' Structure with an embedded structure.
        Dim person3 As New MyPerson3()
        person3.person.first = "John"
        person3.person.last = "Evans"
        person3.age = 27
        LibWrap.TestStructInStruct3(person3)

        ' Structure with an embedded array.
        Dim myStruct As New MyArrayStruct()

        myStruct.flag = False
        Dim array(2) As Integer
        myStruct.vals = array
        myStruct.vals(0) = 1
        myStruct.vals(1) = 4
        myStruct.vals(2) = 9

        Console.WriteLine(vbNewLine + "Structure with array before call:")
        Console.WriteLine(myStruct.flag)
        Console.WriteLine("{0} {1} {2}", myStruct.vals(0),
            myStruct.vals(1), myStruct.vals(2))

        LibWrap.TestArrayInStruct(myStruct)
        Console.WriteLine(vbNewLine + "Structure with array after call:")
        Console.WriteLine(myStruct.flag)
        Console.WriteLine("{0} {1} {2}", myStruct.vals(0),
            myStruct.vals(1), myStruct.vals(2))
    End Sub 'Main
End Class 'App
'</snippet24>
'</snippet22>
