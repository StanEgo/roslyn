﻿// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp.UseCompoundAssignment;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Editor.CSharp.UnitTests.Diagnostics;
using Microsoft.CodeAnalysis.Test.Utilities;
using Xunit;

namespace Microsoft.CodeAnalysis.Editor.CSharp.UnitTests.UseCompoundAssignment
{
    public class UseCompoundAssignmentTests : AbstractCSharpDiagnosticProviderBasedUserDiagnosticTest
    {
        internal override (DiagnosticAnalyzer, CodeFixProvider) CreateDiagnosticProviderAndFixer(Workspace workspace)
            => (new CSharpUseCompoundAssignmentDiagnosticAnalyzer(), new CSharpUseCompoundAssignmentCodeFixProvider());

        [Fact, Trait(Traits.Feature, Traits.Features.CodeActionsUseCompoundAssignment)]
        public async Task TestAddExpression()
        {
            await TestInRegularAndScriptAsync(
@"public class C
{
    void M(int a)
    {
        a [||]= a + 10;
    }
}",
@"public class C
{
    void M(int a)
    {
        a += 10;
    }
}");
        }

        [Fact, Trait(Traits.Feature, Traits.Features.CodeActionsUseCompoundAssignment)]
        public async Task TestSubtractExpression()
        {
            await TestInRegularAndScriptAsync(
@"public class C
{
    void M(int a)
    {
        a [||]= a - 10;
    }
}",
@"public class C
{
    void M(int a)
    {
        a -= 10;
    }
}");
        }

        [Fact, Trait(Traits.Feature, Traits.Features.CodeActionsUseCompoundAssignment)]
        public async Task TestMultiplyExpression()
        {
            await TestInRegularAndScriptAsync(
@"public class C
{
    void M(int a)
    {
        a [||]= a * 10;
    }
}",
@"public class C
{
    void M(int a)
    {
        a *= 10;
    }
}");
        }

        [Fact, Trait(Traits.Feature, Traits.Features.CodeActionsUseCompoundAssignment)]
        public async Task TestDivideExpression()
        {
            await TestInRegularAndScriptAsync(
@"public class C
{
    void M(int a)
    {
        a [||]= a / 10;
    }
}",
@"public class C
{
    void M(int a)
    {
        a /= 10;
    }
}");
        }

        [Fact, Trait(Traits.Feature, Traits.Features.CodeActionsUseCompoundAssignment)]
        public async Task TestModuloExpression()
        {
            await TestInRegularAndScriptAsync(
@"public class C
{
    void M(int a)
    {
        a [||]= a % 10;
    }
}",
@"public class C
{
    void M(int a)
    {
        a %= 10;
    }
}");
        }

        [Fact, Trait(Traits.Feature, Traits.Features.CodeActionsUseCompoundAssignment)]
        public async Task TestBitwiseAndExpression()
        {
            await TestInRegularAndScriptAsync(
@"public class C
{
    void M(int a)
    {
        a [||]= a & 10;
    }
}",
@"public class C
{
    void M(int a)
    {
        a &= 10;
    }
}");
        }

        [Fact, Trait(Traits.Feature, Traits.Features.CodeActionsUseCompoundAssignment)]
        public async Task TestExclusiveOrExpression()
        {
            await TestInRegularAndScriptAsync(
@"public class C
{
    void M(int a)
    {
        a [||]= a ^ 10;
    }
}",
@"public class C
{
    void M(int a)
    {
        a ^= 10;
    }
}");
        }

        [Fact, Trait(Traits.Feature, Traits.Features.CodeActionsUseCompoundAssignment)]
        public async Task TestBitwiseOrExpression()
        {
            await TestInRegularAndScriptAsync(
@"public class C
{
    void M(int a)
    {
        a [||]= a | 10;
    }
}",
@"public class C
{
    void M(int a)
    {
        a |= 10;
    }
}");
        }

        [Fact, Trait(Traits.Feature, Traits.Features.CodeActionsUseCompoundAssignment)]
        public async Task TestLeftShiftExpression()
        {
            await TestInRegularAndScriptAsync(
@"public class C
{
    void M(int a)
    {
        a [||]= a << 10;
    }
}",
@"public class C
{
    void M(int a)
    {
        a <<= 10;
    }
}");
        }

        [Fact, Trait(Traits.Feature, Traits.Features.CodeActionsUseCompoundAssignment)]
        public async Task TestRightShiftExpression()
        {
            await TestInRegularAndScriptAsync(
@"public class C
{
    void M(int a)
    {
        a [||]= a >> 10;
    }
}",
@"public class C
{
    void M(int a)
    {
        a >>= 10;
    }
}");
        }

        [Fact, Trait(Traits.Feature, Traits.Features.CodeActionsUseCompoundAssignment)]
        public async Task TestField()
        {
            await TestInRegularAndScriptAsync(
@"public class C
{
    int a;

    void M()
    {
        a [||]= a + 10;
    }
}",
@"public class C
{
    int a;

    void M()
    {
        a += 10;
    }
}");
        }

        [Fact, Trait(Traits.Feature, Traits.Features.CodeActionsUseCompoundAssignment)]
        public async Task TestFieldWithThis()
        {
            await TestInRegularAndScriptAsync(
@"public class C
{
    int a;

    void M()
    {
        this.a [||]= this.a + 10;
    }
}",
@"public class C
{
    int a;

    void M()
    {
        this.a += 10;
    }
}");
        }

        [Fact, Trait(Traits.Feature, Traits.Features.CodeActionsUseCompoundAssignment)]
        public async Task TestStaticFieldThroughType()
        {
            await TestInRegularAndScriptAsync(
@"public class C
{
    static int a;

    void M()
    {
        C.a [||]= C.a + 10;
    }
}",
@"public class C
{
    static int a;

    void M()
    {
        C.a += 10;
    }
}");
        }

        [Fact, Trait(Traits.Feature, Traits.Features.CodeActionsUseCompoundAssignment)]
        public async Task TestStaticFieldThroughNamespaceAndType()
        {
            await TestInRegularAndScriptAsync(
@"namespace NS
{
    public class C
    {
        static int a;

        void M()
        {
            NS.C.a [||]= NS.C.a + 10;
        }
    }
}",
@"namespace NS
{
    public class C
    {
        static int a;

        void M()
        {
            NS.C.a += 10;
        }
    }
}");
        }

        [Fact, Trait(Traits.Feature, Traits.Features.CodeActionsUseCompoundAssignment)]
        public async Task TestParenthesized()
        {
            await TestInRegularAndScriptAsync(
@"public class C
{
    int a;

    void M()
    {
        (a) [||]= (a) + 10;
    }
}",
@"public class C
{
    int a;

    void M()
    {
        (a) += 10;
    }
}");
        }
    }
}
