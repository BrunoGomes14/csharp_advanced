using devmonkorm.Common;

namespace devmonkorm
{
    public class MerceariaDMContext : DMContext
    {
        public MerceariaDMContext(DMContextOptions options) : base(options)
        {
        }

        public DMSet<Produto> Produtos { get; set; }
    }
}