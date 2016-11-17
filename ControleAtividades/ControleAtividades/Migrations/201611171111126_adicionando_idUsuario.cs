namespace ControleAtividades.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adicionando_idUsuario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Atividades", "UsuarioID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Atividades", "UsuarioID");
        }
    }
}
