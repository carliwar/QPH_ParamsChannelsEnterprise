using Sieve.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QPH_ParamsChannelsEnterprise.Core.CustomEntities
{
    public class PagedList<T> : List<T>
    {
        public Metadata Metadata { get; set; }

        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            var totalPages = (int)Math.Ceiling(count / (double)pageSize);
            Metadata = new Metadata
            {
                TotalCount = count,
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPages = totalPages,
                HasNextPage = pageNumber < totalPages,
                HasPreviousPage = pageNumber > 1
            };

            AddRange(items);
        }

        public static PagedList<T> CreateFromResults(List<T> source, SieveModel sieveModel, int totalCount)
        {
            int pageNumber = sieveModel?.Page ?? 1;
            int pageSize = sieveModel?.PageSize ?? 10;
            return new PagedList<T>(source, totalCount, pageNumber, pageSize);
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
