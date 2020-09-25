## READ_ME

* Dependency
  * ```dotnet add package Microsoft.EntityFrameworkCore.InMemory```
* To test with postman import collection in: 
  * ```postman_collection/JovoVelha.postman_collection.json```
* [Deployed into Heroku](https://devcenter.heroku.com/articles/container-registry-and-runtime)
  * heroku container:push $docker-compose-service-name --app $heroku-app-name
    * ```heroku login```
    * ```heroku apps```
    * ```heroku container:login```
    * Publish
      * ```heroku container:push web -a gmascb-jogovelha```
    * Update
      * ```heroku container:release web --app gmascb-jogovelha```
* Docker
  * docker build . -t jogovelha
  * docker run -it --rm -p 5001:5001 jogovelha
  * sudo docker build . -t jogovelha && sudo docker run -it --rm -p 44501:44501 jogovelha
  * To test in postman with Docker use HTTP instead HTTPS