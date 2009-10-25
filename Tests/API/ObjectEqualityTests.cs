/*
 * Copyright (C) 2009, James Gregory
 *
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or
 * without modification, are permitted provided that the following
 * conditions are met:
 *
 * - Redistributions of source code must retain the above copyright
 *   notice, this list of conditions and the following disclaimer.
 *
 * - Redistributions in binary form must reproduce the above
 *   copyright notice, this list of conditions and the following
 *   disclaimer in the documentation and/or other materials provided
 *   with the distribution.
 *
 * - Neither the name of the Git Development Community nor the
 *   names of its contributors may be used to endorse or promote
 *   products derived from this software without specific prior
 *   written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND
 * CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES,
 * INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES
 * OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
 * ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR
 * CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL,
 * SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT
 * NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES;
 * LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
 * CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT,
 * STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE)
 * ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF
 * ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */

using Git;
using NUnit.Framework;

namespace GitSharp.Tests.API
{
    [TestFixture]
    public class ObjectEqualityTests : RepositoryTestCase
    {
        [Test]
        public void ShouldBeAbleToCompareNullObjects()
        {
            AbstractObject obj = null;

            Assert.IsTrue(obj == null);
        }

        [Test]
        public void ShouldBeAbleToCompareNullObjectsInverse()
        {
            AbstractObject obj = null;

            Assert.IsTrue(null == obj);
        }

        [Test]
        public void SameInstanceShouldBeEqual()
        {
            var repos = new Repository(db);
            var obj = repos.CurrentBranch.CurrentCommit;
#pragma warning disable 1718
            Assert.IsTrue(obj == obj); // [henon] this equality comparison of the same instance is intended
#pragma warning restore 1718
        }

        [Test]
        public void DifferentInstancesShouldntBeEqual()
        {
            var repos = new Repository(db);
            var obj = repos.CurrentBranch.CurrentCommit;
            var obj2 = repos.CurrentBranch.CurrentCommit.Parent;

            Assert.IsTrue(obj != obj2);
        }
    }
}