﻿' <Snippet1>
Imports System.Diagnostics
Imports System.Threading

Class MySample
    Public Shared Sub Main()
        ' Create the source, if it does not already exist.
        If Not EventLog.SourceExists("MySource", "MyServer") Then
            EventLog.CreateEventSource("MySource", "MyNewLog", "MyServer")
            Console.WriteLine("CreatingEventSource")
        End If
        
        ' Create an EventLog instance and assign its source.
        Dim myLog As New EventLog()
        myLog.Source = "MySource"
        
        ' Write an informational entry to the event log.    
        myLog.WriteEntry("Writing to event log.")
        
        Console.WriteLine("Message written to event log.")
    End Sub ' Main
End Class ' MySample
' </Snippet1>