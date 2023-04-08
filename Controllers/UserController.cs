using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Usuario.Model;
using Usuario.Repository;

namespace Usuario.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _repository.GetAll();
            return users.Any()
                ?Ok(users)
                :NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var users = await _repository.GetById(id);
            return users != null
                ?Ok(users)
                :NotFound("Usuário não encontrado!");
        }

        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            _repository.Add(user);
            return await _repository.SaveChangesAsync()
                ?Ok("Usuário adicionado com sucesso!")
                :BadRequest("Erro ao adicionar o usuário!");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, User user)
        {
            var userDB = await _repository.GetById(id);
            if(userDB == null) NotFound("Usuário não encontrado!");

            userDB.Name = user.Name ?? userDB.Name;
            userDB.birthDate = user.birthDate != new DateTime()
                ?user.birthDate 
                :userDB.birthDate;
            
            _repository.Update(userDB);

            return await _repository.SaveChangesAsync()
                ?Ok("Usuário atualizado com sucesso!")
                :BadRequest("Erro ao atualizar o usuário!");
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var userDB = await _repository.GetById(id);
            if(userDB == null) NotFound("Usuário não encontrado!");

            _repository.Delete(userDB);

            return await _repository.SaveChangesAsync()
                ?Ok("Usuário deletado com sucesso!")
                :BadRequest("Erro ao deletar o usuário!");
        }

        
    }
}