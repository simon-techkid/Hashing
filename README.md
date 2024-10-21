# Hashing

## Introduction

Hashing is a library written in .NET Standard 2.0 that allows extensible hashing of objects. It is designed to be used in a variety of scenarios, including caching, indexing, and data retrieval.

## Features

- **Extensible hashing**: Hashing is designed to be extensible, allowing you to create custom hash functions and hash algorithms.
- **Fast and efficient**: Hashing is designed to be fast and efficient, with minimal overhead.
- **Easy to use**: Hashing is designed to be easy to use, with a simple API that allows you to hash objects with a single line of code.
- **Flexible**: Hashing is designed to be flexible, with support for a variety of hash functions and algorithms.
- **Modular**: Hashing is designed to be modular, with support for adding and removing hash functions and algorithms as needed.
- **Versatile**: Hashing is designed to be versatile, with support for a variety of data types and structures.

## Information

- **Language**: C#
- **Platform**: .NET Standard 2.0
- **Dependencies**: None
- **License**: MIT
- **Author**: [Simon Field](https://github.com/simon-techkid)

## Specification

### Hashing.Formats

The `Hashing.Formats` namespace contains classes that represent different hash formats. These classes are used to encode and decode hash values in a variety of formats. 

#### Included Hashing Formats

| Namespace | Object Type | 
|--|--|
| Hashing.Formats.Byte | `byte[]` |
| Hashing.Formats.File | `[FileStream](https://learn.microsoft.com/en-us/dotnet/api/system.io.filestream)` |
| Hashing.Formats.Json | `[List](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1)<[JsonDocument](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.jsondocument)>` |
| Hashing.Formats.Txt  | `string?[]` |
| Hashing.Formats.Xml  | `[IEnumerable](https://learn.microsoft.com/en-us/dotnet/api/system.collections.ienumerable)<[XElement](https://learn.microsoft.com/en-us/dotnet/api/system.xml.linq.xelement)>` |

#### Implementing your own Hashing Formats

All hashing data formats must implement `IHashingProvider<T>` where `T` is the data type being hashed. Hashing formats included in the `Hashing.Formats` namespace also implement `IHashingProvider<T>`.

