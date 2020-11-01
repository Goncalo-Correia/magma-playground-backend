# magma-playground-backend

## API endpoints

  - User - [Route("magma_api/user")]
      - GetById - [HttpGet("{id}")]
      - GetByEmail - [HttpGet("email/{email}")]
      - Create(User) - [HttpPost]
      - Update(User) - [HttpPost("update")]
      - Delete(id) - [HttpDelete("{id}")]
            
  - Home - [Route("magma_api/home")]
      - Login(email,password) - [HttpGet] 
      - Register(User) - [HttpPost] 
            
  - Playground - [Route("magma_api/playground")]
      - GetProjectById - [HttpGet("project/{id}")]
      - Create(Project) - [HttpPost("project/create")]
      - UPdate(Project) - [HttpPost("project/update")]
      
  - Project - [Route("magma_api/project")]
      - GetById - [HttpGet("{id}")]
      - GetByUserId - [HttpGet("user/{userId}")]
      - Create(Project) -  [HttpPost]
      - Update(Project) - [HttpPost("update")]
      - Delete(id) - [HttpDelete("{id}")]
      
  - Track - [Route("magma_api/track")]
      - GetById - [HttpGet("{id}")]
      - GetByProjectId - [HttpGet("project/{projectId}")]
      - Create(Track) -  [HttpPost]
      - Update(Track) - [HttpPost("update")]
      - Delete(id) - [HttpDelete("{id}")]
      
  - Rack - [Route("magma_api/rack")]
      - GetById - [HttpGet("{id}")]
      - GetByTrackId - [HttpGet("track/{trackId}")]
      - Create(Track) -  [HttpPost]
      - Update(Track) - [HttpPost("update")]
      - Delete(id) - [HttpDelete("{id}")]
      
  - Plugin - [Route("magma_api/plugin")]
      - GetById - [HttpGet("{id}")]
      - GetByRackId - [HttpGet("rack/{rackId}")]
      - Create(Rack) -  [HttpPost]
      - Update(Rack) - [HttpPost("update")]
      - Delete(id) - [HttpDelete("{id}")]
      
  - Audio Effect - [Route("magma_api/audioEffect")]
      - GetById - [HttpGet("{id}")]
      - GetByPluginId - [HttpGet("plugin/{pluginId}")]
      - Create(AudioEffect) -  [HttpPost]
      - Update(AudioEffect) - [HttpPost("update")]
      - Delete(id) - [HttpDelete("{id}")]
      
  - Synthesizer - [Route("magma_api/synthesizer")]
      - GetById - [HttpGet("{id}")]
      - GetByPluginId - [HttpGet("plugin/{pluginId}")]
      - Create(Synthesizer) -  [HttpPost]
      - Update(Synthesizer) - [HttpPost("update")]
      - Delete(id) - [HttpDelete("{id}")]
  
  - Sampler - [Route("magma_api/sampler")]
      - GetById - [HttpGet("{id}")]
      - GetByPluginId - [HttpGet("plugin/{pluginId}")]
      - Create(Sampler) -  [HttpPost]
      - Update(Sampler) - [HttpPost("update")]
      - Delete(id) - [HttpDelete("{id}")]

## Model properties
      #### User #####          #### Project #####          #### Track #####          #### Rack #####             
      - id                     - id                        - id                      - id     
      - name                   - name                      - order                   - track id 
      - last name              - created on                - name
      - email                  - updated on                - volume 
      - password               - user id                   - pan 
      - created on                                         - track type
      - updated on                                         - project id 
      
      #### Plugin #####        #### Audio Effect #####     #### Synthesizer #####    #### Sampler #####             
      - id                     - id                        - id                      - id     
      - order                  - order                     - name                    - name 
      - plugin type            - name                      - synthesizer type        - plugin id
      - plugin name            - audio effect type         - plugin id 
      - rack id                - plugin id                   
