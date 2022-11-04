set serviceName = "RDS.Sync.Service-ClientB"
set servicePath = "C:\Test\Sun\DataSync\Sun.RDS.Sync.Service\bin\PublishB\Sun.RDS.Sync.Service.exe"
set groupName = "RDS.Sync"
set startMode = "delayed-auto"

sc create %serviceName % binPath=%servicePath % group=%groupName % displayname=%serviceName % start=%startMode %
Timeout 5
Echo About to Start the service %serviceName %
sc start %serviceName %



