pipeline {
  agent any

  stages {    
    stage("build docker-compose") {
      steps {
        sh 'docker-compose build .'
      }
    }
    
    stage("run docker-compose infrastructure") {
      steps {
        sh 'docker-compose build up -d'
      }
    }
  }
}
