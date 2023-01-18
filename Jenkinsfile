pipeline {
  agent any

  stages {
    stage('Maven Install') {
    	agent {
      	docker {
        	image 'maven:3.5.0'
        }
      }
      steps {
      	sh 'mvn clean install'
      }
    }
    
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
