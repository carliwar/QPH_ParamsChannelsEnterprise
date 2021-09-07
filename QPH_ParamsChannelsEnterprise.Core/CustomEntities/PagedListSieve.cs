using Sieve.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QPH_ParamsChannelsEnterprise.Core.CustomEntities
{
    public class PagedListSieve<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
        public int? NextPageNumber => HasNextPage ? CurrentPage + 1 : (int?)null;
        public int? PreviousPageNumber => HasPreviousPage ? CurrentPage - 1 : (int?)null;

        public PagedListSieve(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }

        public static PagedListSieve<T> CreateFromResults(List<T> source, SieveModel sieveModel, int totalCount)
        {
            int pageNumber = sieveModel?.Page ?? 1;
            int pageSize = sieveModel?.PageSize ?? 10;
            return new PagedListSieve<T>(source, totalCount, pageNumber, pageSize);
        }

        public static PagedListSieve<T> CreateFromQuerable(IQueryable<T> source, int page, int pageSize)
        {
            var rowCount = source.AsEnumerable().Count();
            var items = source.AsEnumerable().Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return new PagedListSieve<T>(items, rowCount, page, pageSize);
        }

        public static List<T> CreateSourceFromQuery(IQueryable<T> source, SieveModel sieveModel)
        {
            int page = sieveModel?.Page ?? 1;
            int pageSize = sieveModel?.PageSize ?? 10;

            List<T> items = source.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return items;
        }
    }
}
