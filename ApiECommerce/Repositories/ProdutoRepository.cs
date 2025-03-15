using ApiECommerce.Context;
using ApiECommerce.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiECommerce.Repositories;

// O repositório atua como uma camada intermediária entre a lógica
// de negócios da aplicação e o mecanismo de persistência de dados
// (banco de dados) e encapsula a lógica de acesso aos dados,
// proporcionando uma abstração que facilita a manutenção, a
// testabilidade e a evolução do código. A principal função do padrão
// Repository é centralizar a lógica de acesso a dados e permitir que
// a lógica de negócios interaja com os dados sem se preocupar com os
// detalhes de persistência.
public class ProdutoRepository : IProdutoRepository
{
    private readonly AppDbContext _dbContext;

    public ProdutoRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // Ao utilizar AsNoTracking, o Entity Framework não acompanha as modificações feitas
    // nos objetos recuperados. Isso significa que o contexto não precisa gerar entradas
    // no gráfico de objetos e não precisa rastrear as entidades para detectar alterações.
    // A desativação do rastreamento pode resultar em um ganho de desempenho considerável,
    // especialmente em consultas complexas ou quando se recupera um grande número de entidades.
    public async Task<IEnumerable<Produto>> ObterProdutosPorCategoriaAsync(int categoriaId)
    {
        return await _dbContext.Produtos
            .Where(p => p.CategoriaId == categoriaId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Produto>> ObterProdutosPopularesAsync()
    {
        return await _dbContext.Produtos.AsNoTracking()
            .Where(p => p.Popular)
            .ToListAsync();
    }

    public async Task<IEnumerable<Produto>> ObterProdutosMaisVendidosAsync()
    {
        return await _dbContext.Produtos.AsNoTracking()
            .Where(p => p.MaisVendido)
            .ToListAsync();
    }

    public async Task<Produto> ObterDetalheProdutoAsync(int id)
    {
        var detalheProduto =  await _dbContext.Produtos.AsNoTracking()
                                              .FirstOrDefaultAsync(p => p.Id == id);

        if (detalheProduto is null)
            throw new InvalidOperationException();

        return detalheProduto;
    }
}
