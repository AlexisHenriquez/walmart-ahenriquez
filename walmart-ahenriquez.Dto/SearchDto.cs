using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace walmart_ahenriquez.Dto
{
    public class SearchDto
    {
        public SearchDto()
        {
            Products = new List<ProductDto>();
        }

        [Required]
        [MinLength(3)]
        public string Value { get; set; }

        public IList<ProductDto> Products { get; set; }
    }
}