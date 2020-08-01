namespace Base.Datos.Contexto
{
    using Base.Datos.Contexto.Entidades;
    using Microsoft.EntityFrameworkCore;

    public partial class Contexto : DbContext
    {
        public Contexto()
        {
        }

        public Contexto(DbContextOptions<Contexto> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Compra> Compra { get; set; }
        public virtual DbSet<InventarioProducto> InventarioProducto { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<ProductoCompraCliente> ProductoCompraCliente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK__Cliente__06370DAD7181F2C4");

                entity.HasIndex(e => e.Cedula)
                    .HasName("UQ__Cliente__B4ADFE388D0A6F14")
                    .IsUnique();

                entity.Property(e => e.FechaNacimiento).HasColumnType("datetime");

                entity.Property(e => e.PrimerApellido)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PrimerNombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.SegundoApellido).HasMaxLength(50);

                entity.Property(e => e.SegundoNombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK__Compra__06370DAD542FCBBC");

                entity.Property(e => e.FechaCompra).HasColumnType("datetime");

                entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<InventarioProducto>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK__Inventar__06370DADBCEA66D1");

                entity.HasOne(d => d.CodigoProductoNavigation)
                    .WithMany(p => p.InventarioProducto)
                    .HasForeignKey(d => d.CodigoProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Productos_InventarioProductos_CodigoProducto");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK__Producto__06370DAD7003C5F6");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Precio).HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<ProductoCompraCliente>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Producto_Compra_Cliente");

                entity.HasOne(d => d.CodigoClienteNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.CodigoCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Productos_Compras_Clientes_CodigoCliente");

                entity.HasOne(d => d.CodigoCompraNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.CodigoCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Productos_Compras_Clientes_CodigoCompra");

                entity.HasOne(d => d.CodigoProductoNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.CodigoProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Productos_Compras_Clientes_CodigoProducto");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}