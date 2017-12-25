#!groovy​

node('gp1') {
	checkout scm
	
	dir('SampleApp') {
		sh('sudo dotnet restore')
        sh('sudo dotnet build /noconsolelogger /logger:CustomLogger.MyLogger,../CustomLogger/bin/Debug/netstandard1.4/CustomLogger.dll')
    }
}
