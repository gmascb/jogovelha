## READ_ME

* Dependency
  * dotnet add package Microsoft.EntityFrameworkCore.InMemory
* To test with postman import collection in: 
  * ```postman_collection/JovoVelha.postman_collection.json```
* Deployed into Heroku
  * heroku container:push $docker-compose-service-name --app $heroku-app-name
* Docker
  * docker build . -t jogovelha
  * docker run -it --rm -p 5001:5001 jogovelha
  * To test in postman with Docker use HTTP instead HTTPS