using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using Hnqn.CrmSys.Models;



namespace Hnqn.CrmSys.Dal
{
    public class CommonRepository<TEntity>
         where TEntity : EntityBase
    {     
        //定义上下文
        internal CrmDbContext context;
        //定义数据集
        internal DbSet<TEntity> dbSet;
        public CommonRepository(CrmDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }
        /// <summary>
        /// 根据条件获取行数
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public int GetCount(Expression<Func<TEntity, bool>> where = null)
        {
            if (where == null)
                return dbSet.Count();
            else
                return dbSet.Count(where);
        }

        /// <summary>
        /// 获取所有符合条件的数据
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAll(Func<TEntity, bool> where)
        {
            IEnumerable<TEntity> query = null;
            if (where == null)
            {
                query = dbSet;
            }
            else
            {
                query = dbSet.Where(where);
            }
            return query;
        }

        /// <summary>
        /// 获取分页数据
        /// </summary>
        /// <param name="where"></param>
        /// <param name="limit">每页多少条</param>
        /// <param name="offset">第几页</param>
        /// <returns></returns>
        ///  
        public IEnumerable<TEntity> GetPageEntitys(Func<TEntity, bool> where, int limit = 10, int offset = 0)
        {
            IEnumerable<TEntity> query = GetAll(where);        
            return query.Skip(limit*offset).Take(limit).ToList();
        }

        /// <summary>
        /// 根据ID查实体
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TEntity GetEntityById(object id)
        {
            return dbSet.Find(id);//根据主键查找实体
        }

        /// <summary>
        /// 根据ID删除
        /// </summary>
        /// <param name="id"></param>
        public void Delete(object id)
        {
            TEntity entity = GetEntityById(id);
            Delete(entity);
        }
        /// <summary>
        /// 根据实体删除
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(TEntity entity)
        {
            if(context.Entry(entity).State == EntityState.Detached)
            {
                //附加到ef容器中
                dbSet.Attach(entity);
            }
            //再从集合里删除
            dbSet.Remove(entity);
        }
        
           
        /// <summary>
        /// 数据添加
        /// </summary>
        /// <param name="entity"></param>
        public void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="excludeFields"></param>
        public void Update(TEntity entity,params string[] excludeFields)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            foreach (var item in excludeFields)
            {
                context.Entry(entity).Property(item).IsModified = false;
            }            
        }
        /// <summary>
        /// 根据条件查询
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> where)
        {
            IEnumerable<TEntity> query = null;
            if (where == null)
            {
                query = this.dbSet;
            }
            else
            {
                query = this.dbSet.Where(where);
            }
            return query;
        }

        /// <summary>
        /// EF执行sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        public int ExecuteSql(string sql, params SqlParameter[] param)
        {
            return context.Database.ExecuteSqlCommand(sql, param);
        }
    }
}
