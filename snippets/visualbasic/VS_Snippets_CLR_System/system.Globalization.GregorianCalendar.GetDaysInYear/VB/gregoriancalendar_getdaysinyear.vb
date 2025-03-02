﻿' The following code example calls GetDaysInYear for 5 years in each era.

' <snippet1>
Imports System.Globalization
Imports Microsoft.VisualBasic

Public Class SamplesGregorianCalendar   
   
   Public Shared Sub Main()

      ' Creates and initializes a GregorianCalendar.
      Dim myCal As New GregorianCalendar()

      ' Displays the header.
      Console.Write("YEAR" + ControlChars.Tab)
      Dim y As Integer
      For y = 2001 To 2005
         Console.Write(ControlChars.Tab + "{0}", y)
      Next y
      Console.WriteLine()

      ' Displays the value of the CurrentEra property.
      Console.Write("CurrentEra:")
      For y = 2001 To 2005
         Console.Write(ControlChars.Tab + "{0}", myCal.GetDaysInYear(y, GregorianCalendar.CurrentEra))
      Next y
      Console.WriteLine()

      ' Displays the values in the Eras property.
      Dim i As Integer
      For i = 0 To myCal.Eras.Length - 1
         Console.Write("Era {0}:" + ControlChars.Tab, myCal.Eras(i))
         For y = 2001 To 2005
            Console.Write(ControlChars.Tab + "{0}", myCal.GetDaysInYear(y, myCal.Eras(i)))
         Next y
         Console.WriteLine()
      Next i

   End Sub 'Main 

End Class 'SamplesGregorianCalendar


'This code produces the following output.
'
'YEAR            2001    2002    2003    2004    2005
'CurrentEra:     365     365     365     366     365
'Era 1:          365     365     365     366     365

' </snippet1>
