using System;
using System.Linq.Expressions;

namespace ECommerce.Data.Abstract;

public interface IRepository<T> where T:class
{
    /// <summary>
    /// ID'ye göre tek bir nesne getirme
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<T> GetByIdAsync(int id);


    /// <summary>
    /// Tüm nesneleri getirme
    /// </summary>
    /// <returns></returns>
    Task<IEnumerable<T>> GetAllAsync();



    /// <summary>
    /// Belirli bir koşula uyan nesneleri getirme
    /// </summary>
    /// <param name="predicate"></param>
    /// <returns></returns>
    Task<IEnumerable<T>> FindAsync(Expression<Func<T,bool>> predicate);



    /// <summary>
    /// Yeni bir nesne ekleme
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task AddAsync(T entity);



    /// <summary>
    /// Bir nesneyi güncelleme
    /// </summary>
    /// <param name="entity"></param>
    void Update(T entity);


    /// <summary>
    /// Bir nesneyi silme
    /// </summary>
    /// <param name="entity"></param>
    void Remove(T entity);
}










/*
var p = await GetByIdAsync(5);
Console.Write(p.Name);


Where(p=>p.Category=="Telefon")
*/