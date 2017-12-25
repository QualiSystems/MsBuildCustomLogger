#!groovy​

node('gp1') {
    dir('SampleApp') {
		scm checkout
		sh('dotnet restore')
        sh('dotnet build /noconsolelogger /logger:CustomLogger.MyLogger,../CustomLogger/bin/Debug/netstandard1.4/CustomLogger.dll')
    }
}
