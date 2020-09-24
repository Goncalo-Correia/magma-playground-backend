# magma-playground-backend

## Controllers

  - User - [Route("magma_api/user")]
      [HttpGet("{id}")]
      [HttpGet("email/{email}")]
      [HttpPost]
      [HttpPost("update")]
      [HttpDelete]
            
  - Home - [Route("magma_api/home")]
      - Login(string email, string password) - [HttpGet] 
      - Register(User user) - [HttpPost] 
            
  - Playground - [Route("magma_api/playground")]
      - 
  - Project - [Route("magma_api/project")]
  - Track - [Route("magma_api/track")]
  - Rack - [Route("magma_api/rack")]
  - Plugin - [Route("magma_api/plugin")]
  - Audio Effect - [Route("magma_api/audioEffect")]
  - Synthesizer - [Route("magma_api/synthesizer")]
  - Sampler - [Route("magma_api/sampler")]

## Services

## Daos

## Models

## Response Utilities
