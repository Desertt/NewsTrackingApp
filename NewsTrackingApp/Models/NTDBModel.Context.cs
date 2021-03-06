﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NewsTrackingApp.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class NTDBEntities : DbContext
    {
        public NTDBEntities()
            : base("name=NTDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Tbl_Haber> Tbl_Haber { get; set; }
        public virtual DbSet<Tbl_Kategori> Tbl_Kategori { get; set; }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_DeleteCategory(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_DeleteCategory", idParameter);
        }
    
        public virtual int sp_DeleteNews(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_DeleteNews", idParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_InsertCategory(Nullable<int> id, string kategoriAdi)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var kategoriAdiParameter = kategoriAdi != null ?
                new ObjectParameter("KategoriAdi", kategoriAdi) :
                new ObjectParameter("KategoriAdi", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_InsertCategory", idParameter, kategoriAdiParameter);
        }
    
        public virtual int sp_InsertNews(Nullable<int> kategoriId, string haberBaslik, string haberIcerik)
        {
            var kategoriIdParameter = kategoriId.HasValue ?
                new ObjectParameter("KategoriId", kategoriId) :
                new ObjectParameter("KategoriId", typeof(int));
    
            var haberBaslikParameter = haberBaslik != null ?
                new ObjectParameter("HaberBaslik", haberBaslik) :
                new ObjectParameter("HaberBaslik", typeof(string));
    
            var haberIcerikParameter = haberIcerik != null ?
                new ObjectParameter("HaberIcerik", haberIcerik) :
                new ObjectParameter("HaberIcerik", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_InsertNews", kategoriIdParameter, haberBaslikParameter, haberIcerikParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual ObjectResult<sp_SelectCategory_Result> sp_SelectCategory(Nullable<int> id, string kategoriAdi)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var kategoriAdiParameter = kategoriAdi != null ?
                new ObjectParameter("KategoriAdi", kategoriAdi) :
                new ObjectParameter("KategoriAdi", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_SelectCategory_Result>("sp_SelectCategory", idParameter, kategoriAdiParameter);
        }
    
        public virtual ObjectResult<sp_SelectNews_Result> sp_SelectNews()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_SelectNews_Result>("sp_SelectNews");
        }
    
        public virtual int sp_UpdateCategory(Nullable<int> id, string kategoriAdi)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var kategoriAdiParameter = kategoriAdi != null ?
                new ObjectParameter("KategoriAdi", kategoriAdi) :
                new ObjectParameter("KategoriAdi", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_UpdateCategory", idParameter, kategoriAdiParameter);
        }
    
        public virtual int sp_UpdateNews(Nullable<int> id, string haberBaslik, string haberIcerik)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var haberBaslikParameter = haberBaslik != null ?
                new ObjectParameter("HaberBaslik", haberBaslik) :
                new ObjectParameter("HaberBaslik", typeof(string));
    
            var haberIcerikParameter = haberIcerik != null ?
                new ObjectParameter("HaberIcerik", haberIcerik) :
                new ObjectParameter("HaberIcerik", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_UpdateNews", idParameter, haberBaslikParameter, haberIcerikParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual ObjectResult<sp_SelectAllNews_Result> sp_SelectAllNews()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_SelectAllNews_Result>("sp_SelectAllNews");
        }
    
        public virtual ObjectResult<Tbl_Haber> Fn_SelectAllNews()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Tbl_Haber>("Fn_SelectAllNews");
        }
    
        public virtual ObjectResult<Tbl_Haber> Fn_SelectAllNews(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Tbl_Haber>("Fn_SelectAllNews", mergeOption);
        }
    
        public virtual int sp_UpdateNews1(Nullable<int> id, Nullable<int> kategoriId, string haberBaslik, string haberIcerik)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var kategoriIdParameter = kategoriId.HasValue ?
                new ObjectParameter("KategoriId", kategoriId) :
                new ObjectParameter("KategoriId", typeof(int));
    
            var haberBaslikParameter = haberBaslik != null ?
                new ObjectParameter("HaberBaslik", haberBaslik) :
                new ObjectParameter("HaberBaslik", typeof(string));
    
            var haberIcerikParameter = haberIcerik != null ?
                new ObjectParameter("HaberIcerik", haberIcerik) :
                new ObjectParameter("HaberIcerik", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_UpdateNews1", idParameter, kategoriIdParameter, haberBaslikParameter, haberIcerikParameter);
        }
    
        public virtual int sp_DeleteNews1(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_DeleteNews1", idParameter);
        }
    
        public virtual int sp_InsertCategory1(string kategoriAdi)
        {
            var kategoriAdiParameter = kategoriAdi != null ?
                new ObjectParameter("KategoriAdi", kategoriAdi) :
                new ObjectParameter("KategoriAdi", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_InsertCategory1", kategoriAdiParameter);
        }
    
        public virtual ObjectResult<sp_SelectAllCategory_Result> sp_SelectAllCategory()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_SelectAllCategory_Result>("sp_SelectAllCategory");
        }
    
        public virtual ObjectResult<Tbl_Kategori> FNC_SelectAllCategory()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Tbl_Kategori>("FNC_SelectAllCategory");
        }
    
        public virtual ObjectResult<Tbl_Kategori> FNC_SelectAllCategory(MergeOption mergeOption)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Tbl_Kategori>("FNC_SelectAllCategory", mergeOption);
        }
    
        public virtual int sp_UpdateCategory1(Nullable<int> id, string kategoriAdi)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var kategoriAdiParameter = kategoriAdi != null ?
                new ObjectParameter("KategoriAdi", kategoriAdi) :
                new ObjectParameter("KategoriAdi", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_UpdateCategory1", idParameter, kategoriAdiParameter);
        }
    
        public virtual int sp_DeleteCategory1(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_DeleteCategory1", idParameter);
        }
    }
}
