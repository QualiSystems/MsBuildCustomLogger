#!groovy​

node('gp1') {
	stage('dotnet build') {
		dir('SampleApp') {
        	sh('dotnet build /noconsolelogger /logger:CustomLogger.MyLogger,../CustomLogger/bin/Debug/netstandard1.4/CustomLogger.dll')
		}
    }
}
