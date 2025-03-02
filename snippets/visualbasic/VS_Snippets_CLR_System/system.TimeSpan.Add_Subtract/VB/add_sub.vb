﻿'<Snippet1>
' Example of the TimeSpan.Add( ) and TimeSpan.Subtract( ) methods.
Imports Microsoft.VisualBasic

Module TimeSpanAddSubDemo
    
    Const dataFmt As String = "{0,-24}{1,24}"

    ' Pad the end of a TimeSpan string with spaces if it does not 
    ' contain milliseconds.
    Function Align( interval As TimeSpan ) As String

        Dim intervalStr As String = interval.ToString( )
        Dim pointIndex  As Integer = intervalStr.IndexOf( ":"c )

        pointIndex = intervalStr.IndexOf( "."c, pointIndex )
        If pointIndex < 0 Then intervalStr &= "        "
        Align = intervalStr
    End Function
    
    ' Display TimeSpan parameters and their sum and difference.
    Sub ShowTimeSpanSumDiff( Left as TimeSpan, Right as TimeSpan )

        Console.WriteLine( )
        Console.WriteLine( dataFmt, "TimeSpan Left", Align( Left ) )
        Console.WriteLine( dataFmt, "TimeSpan Right", Align( Right ) )
        Console.WriteLine( dataFmt, "Left.Add( Right )", _
            Align( Left.Add( Right ) ) )
        Console.WriteLine( dataFmt, "Left.Subtract( Right )", _
            Align( Left.Subtract( Right ) ) )
    End Sub

    Sub Main( )
        Console.WriteLine( _
            "This example of the TimeSpan.Add( ) and " & _
            "TimeSpan.Subtract( ) " & vbCrLf & "methods " & _
            "generates the following output by creating several " & _
            vbCrLf & "pairs of TimeSpan objects and calculating " & _
            "and displaying " & vbCrLf & "the sum " & _
            "and difference of each." )

        ' Create pairs of TimeSpan objects.
        ShowTimeSpanSumDiff( _
            new TimeSpan( 1, 20, 0 ), _
            new TimeSpan( 0, 45, 10 ) )
        ShowTimeSpanSumDiff( _
            new TimeSpan( 1, 10, 20, 30, 40 ), _
            new TimeSpan( -1, 2, 3, 4, 5 ) )
        ShowTimeSpanSumDiff( _
            new TimeSpan( 182, 12, 30, 30, 505 ), _
            new TimeSpan( 182, 11, 29, 29, 495 ) )
        ShowTimeSpanSumDiff( _
            new TimeSpan( 888888888888888 ), _
            new TimeSpan( 999999999999999 ) )
    End Sub
End Module 

' This example of the TimeSpan.Add( ) and TimeSpan.Subtract( )
' methods generates the following output by creating several
' pairs of TimeSpan objects and calculating and displaying
' the sum and difference of each.
' 
' TimeSpan Left                   01:20:00
' TimeSpan Right                  00:45:10
' Left.Add( Right )               02:05:10
' Left.Subtract( Right )          00:34:50
' 
' TimeSpan Left                 1.10:20:30.0400000
' TimeSpan Right                 -21:56:55.9950000
' Left.Add( Right )               12:23:34.0450000
' Left.Subtract( Right )        2.08:17:26.0350000
' 
' TimeSpan Left               182.12:30:30.5050000
' TimeSpan Right              182.11:29:29.4950000
' Left.Add( Right )           365.00:00:00
' Left.Subtract( Right )          01:01:01.0100000
' 
' TimeSpan Left              1028.19:21:28.8888888
' TimeSpan Right             1157.09:46:39.9999999
' Left.Add( Right )          2186.05:08:08.8888887
' Left.Subtract( Right )     -128.14:25:11.1111111
'</Snippet1>