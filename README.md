# Taxas

### Endpoints
- /taxaJuros
- /token

Para o endpoint Token, é necessário enviar no body **"9eaa8580-cdda-4354-bdae-9e5a1be59e0b"**

### Repositórios
- https://github.com/JFRode/SDK
- https://github.com/JFRode/CalculadoraDeJuros

### Collection do Postman
Para facilitar o teste da aplicação, importe o arquivo da collection do Postman. Para isso abra o [Postman](https://www.postman.com) e siga as instruções abaixo:
- No menu File clique em Import;
- Na aba **File** clique em **Upload files**;
- Selecione o arquivo [Calculadora de Juros.postman_collection.json](https://github.com/JFRode/Taxas/blob/master/Calculadora%20de%20Juros.postman_collection.json).

### Docker
Na pasta raiz do projeto, mesma que se encontra o arquivo .yml, execute:
- Para criar as imagens: ```docker build -t calculadoradejuros:1.0 .```

Arquivo ```docker-compose.yml``` no repositório [CalculadoraDeJuros](https://github.com/JFRode/CalculadoraDeJuros)

#### DockerHub
- https://hub.docker.com/repository/docker/joaofelipegoncalves/taxas
- https://hub.docker.com/repository/docker/joaofelipegoncalves/calculadoradejuros
