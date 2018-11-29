2018-11-19T23:46:31  PID[10320] Information Executing 'SchedulingFunctions.ProcessCancelAppointmentRequest' (Reason='New queue message detected on 'cancel-appointment-queue'.', Id=647787bc-94a5-453d-a1bf-415b8ffad1ac)
2018-11-19T23:46:32  PID[10320] Information 2018-11-19 23:46:32 [Information] Getting TenantPMS Info for Tenant ID madh-dev.helix.medicaldirector.com , AppId 77699511-0600-4ecc-8097-bf4d93998349
2018-11-19T23:46:32  PID[10320] Information 2018-11-19 23:46:32 [Information] Deleting Appointment in PMS https://devff01-api.hub.medicaldirector.com/fhir/Appointment/MD2540

2018-11-19T23:46:32  PID[10320] Information 2018-11-19 23:46:32 [Information] Deleting : https://madh-dev.helix.medicaldirector.com/api/fhir/Appointment?appointment=https:%2F%2Fdevff01-api.hub.medicaldirector.com%2Ffhir%2FAppointment%2FMD2540

2018-11-19T23:46:33  PID[10320] Information 2018-11-19 23:46:33 [Information] Helix Adapter returned HTTP Error System.Net.Http.StreamContent
2018-11-19T23:46:33  PID[10320] Information 2018-11-19 23:46:33 [Warning] Helix responded with NotFound for https://devff01-api.hub.medicaldirector.com/fhir/Appointment/MD2540

2018-11-19T23:46:33  PID[10320] Information 2018-11-19 23:46:33 [Error] 
2018-11-19T23:46:33  PID[10320] Information MD.Hub.Common.Exceptions.ClientAdapterException: Delete Failed on HelixFhirAdapter ---> System.Exception: Helix Fhir Adapter returned NotFound
2018-11-19T23:46:33  PID[10320] Information    at MD.Hub.Common.ClientAdapters.HelixFhirAdapter.<DeleteAsync>d__14.MoveNext() in C:\BuildAgent\_work\3\s\MDHub\Md.Hub.Common\ClientAdapters\Impl\HelixFhirAdapter.cs:line 137
2018-11-19T23:46:33  PID[10320] Information    --- End of inner exception stack trace ---
2018-11-19T23:46:33  PID[10320] Information    at MD.Hub.Common.ClientAdapters.HelixFhirAdapter.<DeleteAsync>d__14.MoveNext() in C:\BuildAgent\_work\3\s\MDHub\Md.Hub.Common\ClientAdapters\Impl\HelixFhirAdapter.cs:line 142
2018-11-19T23:46:33  PID[10320] Information --- End of stack trace from previous location where exception was thrown ---
2018-11-19T23:46:33  PID[10320] Information    at System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
2018-11-19T23:46:33  PID[10320] Information    at System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
2018-11-19T23:46:33  PID[10320] Information    at System.Runtime.CompilerServices.TaskAwaiter.ValidateEnd(Task task)
2018-11-19T23:46:33  PID[10320] Information    at MD.Hub.Processors.Scheduling.Processor.CancelAppointmentMessageProcessor.<ProcessRequestAsync>d__4.MoveNext() in C:\BuildAgent\_work\3\s\MDHub\MD.Hub.SchedulingMessageProcessor\Processor\CancelAppointmentMessageProcessor.cs:line 239
