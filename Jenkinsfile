pipeline {
  agent any

  stages {
    stage("docker") {
      steps {
        sh 'docker --version'
        sh 'docker-compose version'
      }
    }
    
    stage("frontend-test") {
      steps {
        echo 'frontend-test'
      }
    }
    
    stage("build-backend") {
      steps {
        echo 'build-backend'
      }
    }
    
    stage("build-frontend") {
      steps {
        echo 'build-frontend'
      }
    }
    
    stage("deploy") {
      steps {
        echo 'deploy'
      }
    }
  }
}
