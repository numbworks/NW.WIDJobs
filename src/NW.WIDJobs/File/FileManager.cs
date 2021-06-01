﻿using System;
using System.IO;
using System.Collections.Generic;

namespace NW.WIDJobs
{
    /// <summary><inheritdoc cref="IFileManager"/></summary>
    public class FileManager : IFileManager
    {

        #region Fields

        private IFileAdapter _fileAdapter;

        #endregion

        #region Properties
        #endregion

        #region Constructors

        /// <summary>Initializes a <see cref="FileManager"/> instance using <paramref name="fileAdapter"/></summary>
        public FileManager(IFileAdapter fileAdapter)
        {

            Validator.ValidateObject(fileAdapter, nameof(fileAdapter));

            _fileAdapter = fileAdapter;

        }

        /// <summary>Initializes a <see cref="FileManager"/> instance using default parameters.</summary>        
        public FileManager()
        {

            _fileAdapter = new FileAdapter();

        }

        #endregion

        #region Methods_public

        public IEnumerable<string> ReadAllLines(IFileInfoAdapter file)
        {

            Validator.ValidateObject(file, nameof(file));
            Validator.ValidateFileExistance(file);

            try
            {

                return _fileAdapter.ReadAllLines(file.FullName);

            }
            catch (Exception e)
            {

                throw new Exception(MessageCollection.FileManager_NotPossibleToRead.Invoke(file, e), e);

            }

        }
        public string ReadAllText(IFileInfoAdapter file)
        {

            Validator.ValidateObject(file, nameof(file));
            Validator.ValidateFileExistance(file);

            try
            {

                return _fileAdapter.ReadAllText(file.FullName);

            }
            catch (Exception e)
            {

                throw new Exception(MessageCollection.FileManager_NotPossibleToRead.Invoke(file, e), e);

            }

        }
        public void WriteAllLines(IFileInfoAdapter file, IEnumerable<string> content)
        {

            Validator.ValidateObject(file, nameof(file));

            try
            {

                _fileAdapter.WriteAllLines(file.FullName, content);

            }
            catch (Exception e)
            {

                throw new Exception(MessageCollection.FileManager_NotPossibleToWrite.Invoke(file, e), e);

            }

        }
        public void WriteAllText(IFileInfoAdapter file, string content)
        {

            Validator.ValidateObject(file, nameof(file));

            try
            {

                _fileAdapter.WriteAllText(file.FullName, content);

            }
            catch (Exception e)
            {

                throw new Exception(MessageCollection.FileManager_NotPossibleToWrite.Invoke(file, e), e);

            }

        }
        public FileInfoAdapter Create(string filePath)
            => Create(new FileInfo(filePath));
        public FileInfoAdapter Create(FileInfo fileInfo)
            => new FileInfoAdapter(fileInfo);

        #endregion

    }
}

/*
    Author: numbworks@gmail.com
    Last Update: 30.05.2021
*/