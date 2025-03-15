using ApiECommerce.Entities;

namespace ApiECommerce.Repositories
{
    // A interface atua como um contrato que define as operações
    // que o repositório deve fornecer. Ela lista os métodos que
    // serão implementados, sem se preocupar com os detalhes da
    // implementação. O objetivo principal de definir uma interface
    // antes de implementar o repositório é garantir que haja uma
    // abstração clara entre o comportamento (o que o repositório faz)
    // e a implementação (como o repositório faz).
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> ObterProdutosPorCategoriaAsync(int categoriaId);
        Task<IEnumerable<Produto>> ObterProdutosPopularesAsync();
        Task<IEnumerable<Produto>> ObterProdutosMaisVendidosAsync();
        Task<Produto> ObterDetalheProdutoAsync(int id);
    }
}
