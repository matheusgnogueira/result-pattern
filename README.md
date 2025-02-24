# Result Pattern Study

Este projeto é um estudo sobre o uso do **Result Pattern** para evitar exceções desnecessárias e tornar o código mais previsível e organizado.

## Tecnologias Utilizadas

- .NET 8
- ASP.NET Minimal API
- Entity Framework Core (InMemory Database)
- OneOf (para Result Pattern)

## Como Funciona?

- Erros são representados como tipos específicos, evitando exceções.
- O serviço retorna `OneOf<TSuccess, TError>` ao invés de lançar exceções.
- A API trata os resultados explicitamente com `Match`.

## Executando o Projeto

1. Clone o repositório:
   ```sh
   git clone https://github.com/seu-usuario/result-pattern-study.git
   ```
2. Acesse a pasta do projeto:
   ```sh
   cd result-pattern-study
   ```
3. Restaure os pacotes:
   ```sh
   dotnet restore
   ```
4. Execute a aplicação:
   ```sh
   dotnet run
   ```
5. Acesse o Swagger UI:
   ```
   https://localhost:5001/swagger
   ```

