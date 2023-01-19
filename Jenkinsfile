pipeline {
  agent any

  stages {    
    stage("test") {
      steps {
        sh 'docker-compose --version'
        sh 'docker --version'
      }
    }
  }
}
