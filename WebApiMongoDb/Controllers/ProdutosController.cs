﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiMongoDb.Model;
using WebApiMongoDb.Service;

namespace WebApiMongoDb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutoService _produtoService;

        public ProdutosController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public async Task<List<Produto>> GetProduts()
            => await _produtoService.GetAsync();

        [HttpPost]
        public async Task<Produto> PostProduto(Produto produto)
        {
            await _produtoService.CreatAsync(produto);

            return produto;
        }  
    }
}
