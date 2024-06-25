// --- FUNCTIONS
fun add(a: s32, b: s32): s32
{
    return a + b;
}

fun print()
{
    stdout("Hello, world!");
}

// --- STRUCTURES
// Traits declares which extension methods a type must have defined
trait TAdd
{
    fun add(this: ref Foo): s32;
}

// Types declare a custom user type
type Foo : TAdd
{
    a: s32;
    b: s32;
}

// An extension method can be called from a type instance.
fun add(this: ref Foo): s32
{
    return this.a + this.b;
}

Definitions:

Type:       `type <identifier>[: <traits>] {}`
Function:   `fun <identifier>([<parameters>])[: <return type>] {}`
Variable:   `var <identifier>[: <type>][= <value>]`
