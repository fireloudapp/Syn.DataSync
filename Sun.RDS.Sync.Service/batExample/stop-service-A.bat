set serviceName = "RDS.Sync.Service-ClientA"

sc stop %serviceName %
Timeout 10
Echo About to Remove the service %serviceName %
sc delete %serviceName %