pipeline {
  agent any
  stages {
    stage('Clean workspaces') {
      steps {
        deleteDir()
      }
    }
    stage ('Git Checkout') {
      steps {
      git branch: 'master', credentialsId: '<id-of-Jenkins-credentials>', url: 'https://github.com/brian-chase/sharpyexample.core.git'
      }
    }
    stage('Restore packages') {
      steps {
      bat "dotnet restore ${workspace}\\sharpyexample.core\\SharpyExample.Core.sln"
      }
    }
    stage('Clean') {
      steps {
      bat "msbuild.exe ${workspace}\\sharpyexample.core\\SharpyExample.Core.sln /nologo /nr:false /p:platform=\"x64\" /p:configuration=\"release\" /t:clean"
      }
    }
    stage('Build') {
      steps {
        bat "msbuild.exe ${workspace}\\sharpyexample.core\\SharpyExample.Core.sln /nologo /nr:false  /p:platform=\"x64\" /p:configuration=\"release\" /t:clean;restore;rebuild"
      }
    }
    stage('Running unit tests') {
      steps {
        bat "dotnet add ${workspace}/<path-to-Unit-testing-project>/<name-of-unit-test-project>.csproj package JUnitTestLogger --version 1.1.0"
        bat "dotnet test ${workspace}/<path-to-Unit-testing-project>/<name-of-unit-test-project>.csproj --logger \"junit;LogFilePath=\"${WORKSPACE}\"/TestResults/1.0.0.\"${env.BUILD_NUMBER}\"/results.xml\" --configuration release --collect \"Code coverage\""
        powershell '''
          $destinationFolder = \"$env:WORKSPACE/TestResults\"
          if (!(Test-Path -path $destinationFolder)) {New-Item $destinationFolder -Type Directory}
          $file = Get-ChildItem -Path \"$env:WORKSPACE/<path-to-Unit-testing-project>/<name-of-unit-test-project>/TestResults/*/*.coverage\"
          $file | Rename-Item -NewName testcoverage.coverage
          $renamedFile = Get-ChildItem -Path \"$env:WORKSPACE/<path-to-Unit-testing-project>/<name-of-unit-test-project>/TestResults/*/*.coverage\"
          Copy-Item $renamedFile -Destination $destinationFolder
        '''            
      }        
    }
  }
}