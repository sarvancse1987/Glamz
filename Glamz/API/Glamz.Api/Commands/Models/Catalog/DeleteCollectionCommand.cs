﻿using Glamz.Api.DTOs.Catalog;
using MediatR;

namespace Glamz.Api.Commands.Models.Catalog
{
    public class DeleteCollectionCommand : IRequest<bool>
    {
        public CollectionDto Model { get; set; }
    }
}
