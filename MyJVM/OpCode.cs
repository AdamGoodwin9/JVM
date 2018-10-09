using System;
using System.Collections.Generic;
using System.Text;

namespace MyJVM
{
    enum OpCode
    {
        nop = 00,
        aconst_null = 0x01,
        iconst_m1 = 0x02,
        iconst_0 = 0x03,
        iconst_1 = 0x04,
        iconst_2 = 0x05,
        iconst_3 = 0x06,
        iconst_4 = 0x07,
        iconst_5 = 0x08,
        lconst_0 = 0x09,
        lconst_1 = 0x0a,
        fconst_0 = 0x0b,
        fconst_1 = 0x0c,
        fconst_2 = 0x0d,
        dconst_0 = 0x0e,
        dconst_1 = 0x0f,
        bipush = 0x10,
        sipush = 0x11,
        ldc = 0x12,
        ldc_w = 0x13,
        ldc2_w = 0x14,
        iload = 0x15,
        lload = 0x16,
        fload = 0x17,
        dload = 0x18,
        aload = 0x19,
        iload_0 = 0x1a,
        iload_1 = 0x1b,
        iload_2 = 0x1c,
        iload_3 = 0x1d,
        lload_0 = 0x1e,
        lload_1 = 0x1f,
        lload_2 = 0x20,
        lload_3 = 0x21,
        fload_0 = 0x22,
        fload_1 = 0x23,
        fload_2 = 0x24,
        fload_3 = 0x25,
        dload_0 = 0x26,
        dload_1 = 0x27,
        dload_2 = 0x28,
        dload_3 = 0x29,
        aload_0 = 0x2a,
        aload_1 = 0x2b,
        aload_2 = 0x2c,
        aload_3 = 0x2d,
        iaload = 0x2e,
        laload = 0x2f,
        faload = 0x30,
        daload = 0x31,
        aaload = 0x32,
        baload = 0x33,
        caload = 0x34,
        saload = 0x35,
        istore = 0x36,
        lstore = 0x37,
        fstore = 0x38,
        dstore = 0x39,
        astore = 0x3a,
        istore_0	3b	0011 1011		value →	store int value into variable 0
istore_1	3c	0011 1100		value →	store int value into variable 1
istore_2	3d	0011 1101		value →	store int value into variable 2
istore_3	3e	0011 1110		value →	store int value into variable 3
lstore_0	3f	0011 1111		value →	store a long value in a local variable 0
lstore_1	40	0100 0000		value →	store a long value in a local variable 1
lstore_2	41	0100 0001		value →	store a long value in a local variable 2
lstore_3	42	0100 0010		value →	store a long value in a local variable 3
fstore_0	43	0100 0011		value →	store a float value into local variable 0
fstore_1	44	0100 0100		value →	store a float value into local variable 1
fstore_2	45	0100 0101		value →	store a float value into local variable 2
fstore_3	46	0100 0110		value →	store a float value into local variable 3
dstore_0	47	0100 0111		value →	store a double into local variable 0
dstore_1	48	0100 1000		value →	store a double into local variable 1
dstore_2	49	0100 1001		value →	store a double into local variable 2
dstore_3	4a	0100 1010		value →	store a double into local variable 3
astore_0	4b	0100 1011		objectref →	store a reference into local variable 0
astore_1	4c	0100 1100		objectref →	store a reference into local variable 1
astore_2	4d	0100 1101		objectref →	store a reference into local variable 2
astore_3	4e	0100 1110		objectref →	store a reference into local variable 3
iastore	4f	0100 1111		arrayref, index, value →	store an int into an array
lastore	50	0101 0000		arrayref, index, value →	store a long to an array
fastore	51	0101 0001		arrayref, index, value →	store a float in an array
dastore	52	0101 0010		arrayref, index, value →	store a double into an array
aastore	53	0101 0011		arrayref, index, value →	store into a reference in an array
bastore	54	0101 0100		arrayref, index, value →	store a byte or Boolean value into an array
castore	55	0101 0101		arrayref, index, value →	store a char into an array
sastore	56	0101 0110		arrayref, index, value →	store short to array
pop	57	0101 0111		value →	discard the top value on the stack
pop2	58	0101 1000		{value2, value1
    } →	discard the top two values on the stack(or one value, if it is a double or long)
dup	59	0101 1001		value → value, value duplicate the value on top of the stack
dup_x1  5a	0101 1010		value2, value1 → value1, value2, value1 insert a copy of the top value into the stack two values from the top.value1 and value2 must not be of the type double or long.
dup_x2  5b  0101 1011		value3, value2, value1 → value1, value3, value2, value1 insert a copy of the top value into the stack two (if value2 is double or long it takes up the entry of value3, too) or three values(if value2 is neither double nor long) from the top
dup2    5c	0101 1100		{value2, value1
} → {value2, value1}, {value2, value1}	duplicate top two stack words(two values, if value1 is not double nor long; a single value, if value1 is double or long)
dup2_x1	5d	0101 1101		value3, {value2, value1} → {value2, value1}, value3, {value2, value1}	duplicate two words and insert beneath third word(see explanation above)
dup2_x2	5e	0101 1110		{value4, value3}, {value2, value1} → {value2, value1}, {value4, value3}, {value2, value1}	duplicate two words and insert beneath fourth word
swap	5f	0101 1111		value2, value1 → value1, value2 swaps two top words on the stack(note that value1 and value2 must not be double or long)
iadd	60	0110 0000		value1, value2 → result add two ints
ladd	61	0110 0001		value1, value2 → result add two longs
fadd	62	0110 0010		value1, value2 → result add two floats
dadd	63	0110 0011		value1, value2 → result add two doubles
isub	64	0110 0100		value1, value2 → result int subtract
lsub	65	0110 0101		value1, value2 → result subtract two longs
fsub	66	0110 0110		value1, value2 → result subtract two floats
dsub	67	0110 0111		value1, value2 → result subtract a double from another
imul    68	0110 1000		value1, value2 → result multiply two integers
lmul	69	0110 1001		value1, value2 → result multiply two longs
fmul	6a	0110 1010		value1, value2 → result multiply two floats
dmul	6b	0110 1011		value1, value2 → result multiply two doubles
idiv	6c	0110 1100		value1, value2 → result divide two integers
ldiv	6d	0110 1101		value1, value2 → result divide two longs
fdiv	6e	0110 1110		value1, value2 → result divide two floats
ddiv	6f	0110 1111		value1, value2 → result divide two doubles
irem	70	0111 0000		value1, value2 → result logical int remainder
lrem	71	0111 0001		value1, value2 → result remainder of division of two longs
frem    72	0111 0010		value1, value2 → result get the remainder from a division between two floats
drem	73	0111 0011		value1, value2 → result get the remainder from a division between two doubles
ineg	74	0111 0100		value → result negate int
lneg    75	0111 0101		value → result negate a long
fneg    76	0111 0110		value → result negate a float
dneg    77	0111 0111		value → result negate a double
ishl    78	0111 1000		value1, value2 → result int shift left
lshl    79	0111 1001		value1, value2 → result bitwise shift left of a long value1 by int value2 positions
ishr    7a	0111 1010		value1, value2 → result int arithmetic shift right
lshr	7b	0111 1011		value1, value2 → result bitwise shift right of a long value1 by int value2 positions
iushr   7c	0111 1100		value1, value2 → result int logical shift right
lushr	7d	0111 1101		value1, value2 → result bitwise shift right of a long value1 by int value2 positions, unsigned
iand    7e	0111 1110		value1, value2 → result perform a bitwise AND on two integers
land	7f	0111 1111		value1, value2 → result bitwise AND of two longs
ior	80	1000 0000		value1, value2 → result bitwise int OR
lor	81	1000 0001		value1, value2 → result bitwise OR of two longs
ixor	82	1000 0010		value1, value2 → result int xor
lxor	83	1000 0011		value1, value2 → result bitwise XOR of two longs
iinc	84	1000 0100	2: index, const [No change] increment local variable #index by signed byte const
i2l	85	1000 0101		value → result convert an int into a long
i2f 86	1000 0110		value → result convert an int into a float
i2d 87	1000 0111		value → result convert an int into a double
l2i 88	1000 1000		value → result convert a long to a int
l2f 89	1000 1001		value → result convert a long to a float
l2d 8a	1000 1010		value → result convert a long to a double
f2i 8b	1000 1011		value → result convert a float to an int
f2l 8c	1000 1100		value → result convert a float to a long
f2d 8d	1000 1101		value → result convert a float to a double
d2i 8e	1000 1110		value → result convert a double to an int
d2l 8f	1000 1111		value → result convert a double to a long
d2f 90	1001 0000		value → result convert a double to a float
i2b 91	1001 0001		value → result convert an int into a byte
i2c 92	1001 0010		value → result convert an int into a character
i2s	93	1001 0011		value → result convert an int into a short
lcmp    94	1001 0100		value1, value2 → result push 0 if the two longs are the same, 1 if value1 is greater than value2, -1 otherwise
fcmpl   95	1001 0101		value1, value2 → result compare two floats
fcmpg	96	1001 0110		value1, value2 → result compare two floats
dcmpl	97	1001 0111		value1, value2 → result compare two doubles
dcmpg	98	1001 1000		value1, value2 → result compare two doubles
ifeq	99	1001 1001	2: branchbyte1, branchbyte2 value →	if value is 0, branch to instruction at branchoffset(signed short constructed from unsigned bytes branchbyte1 << 8 + branchbyte2)
ifne	9a	1001 1010	2: branchbyte1, branchbyte2 value →	if value is not 0, branch to instruction at branchoffset(signed short constructed from unsigned bytes branchbyte1 << 8 + branchbyte2)
iflt	9b	1001 1011	2: branchbyte1, branchbyte2 value →	if value is less than 0, branch to instruction at branchoffset(signed short constructed from unsigned bytes branchbyte1 << 8 + branchbyte2)
ifge	9c	1001 1100	2: branchbyte1, branchbyte2 value →	if value is greater than or equal to 0, branch to instruction at branchoffset(signed short constructed from unsigned bytes branchbyte1 << 8 + branchbyte2)
ifgt	9d	1001 1101	2: branchbyte1, branchbyte2 value →	if value is greater than 0, branch to instruction at branchoffset(signed short constructed from unsigned bytes branchbyte1 << 8 + branchbyte2)
ifle	9e	1001 1110	2: branchbyte1, branchbyte2 value →	if value is less than or equal to 0, branch to instruction at branchoffset(signed short constructed from unsigned bytes branchbyte1 << 8 + branchbyte2)
if_icmpeq	9f	1001 1111	2: branchbyte1, branchbyte2 value1, value2 →	if ints are equal, branch to instruction at branchoffset(signed short constructed from unsigned bytes branchbyte1 << 8 + branchbyte2)
if_icmpne a0  1010 0000	2: branchbyte1, branchbyte2 value1, value2 →	if ints are not equal, branch to instruction at branchoffset(signed short constructed from unsigned bytes branchbyte1 << 8 + branchbyte2)
if_icmplt a1  1010 0001	2: branchbyte1, branchbyte2 value1, value2 →	if value1 is less than value2, branch to instruction at branchoffset(signed short constructed from unsigned bytes branchbyte1 << 8 + branchbyte2)
if_icmpge a2  1010 0010	2: branchbyte1, branchbyte2 value1, value2 →	if value1 is greater than or equal to value2, branch to instruction at branchoffset(signed short constructed from unsigned bytes branchbyte1 << 8 + branchbyte2)
if_icmpgt a3  1010 0011	2: branchbyte1, branchbyte2 value1, value2 →	if value1 is greater than value2, branch to instruction at branchoffset(signed short constructed from unsigned bytes branchbyte1 << 8 + branchbyte2)
if_icmple a4  1010 0100	2: branchbyte1, branchbyte2 value1, value2 →	if value1 is less than or equal to value2, branch to instruction at branchoffset(signed short constructed from unsigned bytes branchbyte1 << 8 + branchbyte2)
if_acmpeq a5  1010 0101	2: branchbyte1, branchbyte2 value1, value2 →	if references are equal, branch to instruction at branchoffset(signed short constructed from unsigned bytes branchbyte1 << 8 + branchbyte2)
if_acmpne a6  1010 0110	2: branchbyte1, branchbyte2 value1, value2 →	if references are not equal, branch to instruction at branchoffset(signed short constructed from unsigned bytes branchbyte1 << 8 + branchbyte2)
goto	a7	1010 0111	2: branchbyte1, branchbyte2[no change] goes to another instruction at branchoffset(signed short constructed from unsigned bytes branchbyte1 << 8 + branchbyte2)
jsr a8  1010 1000	2: branchbyte1, branchbyte2	→ address jump to subroutine at branchoffset(signed short constructed from unsigned bytes branchbyte1 << 8 + branchbyte2) and place the return address on the stack
ret a9  1010 1001	1: index[No change]	continue execution from address taken from a local variable #index (the asymmetry with jsr is intentional)
tableswitch aa  1010 1010	16+: [0–3 bytes padding], defaultbyte1, defaultbyte2, defaultbyte3, defaultbyte4, lowbyte1, lowbyte2, lowbyte3, lowbyte4, highbyte1, highbyte2, highbyte3, highbyte4, jump offsets...index →	continue execution from an address in the table at offset index
lookupswitch    ab  1010 1011	8+: <0–3 bytes padding>, defaultbyte1, defaultbyte2, defaultbyte3, defaultbyte4, npairs1, npairs2, npairs3, npairs4, match-offset pairs...	key →	a target address is looked up from a table using a key and execution continues from the instruction at that address
ireturn ac  1010 1100		value → [empty]	return an integer from a method
lreturn ad	1010 1101		value → [empty]	return a long value
freturn ae  1010 1110		value → [empty]	return a float
dreturn af	1010 1111		value → [empty]	return a double from a method
areturn b0  1011 0000		objectref → [empty]	return a reference from a method
return	b1	1011 0001		→ [empty]	return void from method
getstatic	b2	1011 0010	2: indexbyte1, indexbyte2	→ value	get a static field value of a class, where the field is identified by field reference in the constant pool index (indexbyte1 << 8 + indexbyte2)
putstatic	b3	1011 0011	2: indexbyte1, indexbyte2	value →	set static field to value in a class, where the field is identified by a field reference index in constant pool (indexbyte1 << 8 + indexbyte2)
getfield	b4	1011 0100	2: indexbyte1, indexbyte2	objectref → value	get a field value of an object objectref, where the field is identified by field reference in the constant pool index (indexbyte1 << 8 + indexbyte2)
putfield	b5	1011 0101	2: indexbyte1, indexbyte2	objectref, value →	set field to value in an object objectref, where the field is identified by a field reference index in constant pool (indexbyte1 << 8 + indexbyte2)
invokevirtual	b6	1011 0110	2: indexbyte1, indexbyte2	objectref, [arg1, arg2, ...] → result	invoke virtual method on object objectref and puts the result on the stack (might be void); the method is identified by method reference index in constant pool (indexbyte1 << 8 + indexbyte2)
invokespecial	b7	1011 0111	2: indexbyte1, indexbyte2	objectref, [arg1, arg2, ...] → result	invoke instance method on object objectref and puts the result on the stack (might be void); the method is identified by method reference index in constant pool (indexbyte1 << 8 + indexbyte2)
invokestatic	b8	1011 1000	2: indexbyte1, indexbyte2	[arg1, arg2, ...] → result	invoke a static method and puts the result on the stack (might be void); the method is identified by method reference index in constant pool (indexbyte1 << 8 + indexbyte2)
invokeinterface	b9	1011 1001	4: indexbyte1, indexbyte2, count, 0	objectref, [arg1, arg2, ...] → result	invokes an interface method on object objectref and puts the result on the stack (might be void); the interface method is identified by method reference index in constant pool (indexbyte1 << 8 + indexbyte2)
invokedynamic	ba	1011 1010	4: indexbyte1, indexbyte2, 0, 0	[arg1, [arg2 ...]] → result	invokes a dynamic method and puts the result on the stack (might be void); the method is identified by method reference index in constant pool (indexbyte1 << 8 + indexbyte2)
new	bb	1011 1011	2: indexbyte1, indexbyte2	→ objectref	create new object of type identified by class reference in constant pool index (indexbyte1 << 8 + indexbyte2)
newarray	bc	1011 1100	1: atype	count → arrayref	create new array with count elements of primitive type identified by atype
anewarray	bd	1011 1101	2: indexbyte1, indexbyte2	count → arrayref	create a new array of references of length count and component type identified by the class reference index (indexbyte1 << 8 + indexbyte2) in the constant pool
arraylength	be	1011 1110		arrayref → length	get the length of an array
athrow	bf	1011 1111		objectref → [empty], objectref	throws an error or exception (notice that the rest of the stack is cleared, leaving only a reference to the Throwable)
checkcast	c0	1100 0000	2: indexbyte1, indexbyte2	objectref → objectref	checks whether an objectref is of a certain type, the class reference of which is in the constant pool at index (indexbyte1 << 8 + indexbyte2)
instanceof	c1	1100 0001	2: indexbyte1, indexbyte2	objectref → result	determines if an object objectref is of a given type, identified by class reference index in constant pool (indexbyte1 << 8 + indexbyte2)
monitorenter	c2	1100 0010		objectref →	enter monitor for object ("grab the lock" – start of synchronized() section)
monitorexit	c3	1100 0011		objectref →	exit monitor for object ("release the lock" – end of synchronized() section)
wide	c4	1100 0100	3/5: opcode, indexbyte1, indexbyte2
or
iinc, indexbyte1, indexbyte2, countbyte1, countbyte2	[same as for corresponding instructions]	execute opcode, where opcode is either iload, fload, aload, lload, dload, istore, fstore, astore, lstore, dstore, or ret, but assume the index is 16 bit; or execute iinc, where the index is 16 bits and the constant to increment by is a signed 16 bit short
multianewarray	c5	1100 0101	3: indexbyte1, indexbyte2, dimensions	count1, [count2,...] → arrayref	create a new array of dimensions dimensions of type identified by class reference in constant pool index (indexbyte1 << 8 + indexbyte2); the sizes of each dimension is identified by count1, [count2, etc.]
ifnull	c6	1100 0110	2: branchbyte1, branchbyte2	value →	if value is null, branch to instruction at branchoffset (signed short constructed from unsigned bytes branchbyte1 << 8 + branchbyte2)
ifnonnull	c7	1100 0111	2: branchbyte1, branchbyte2	value →	if value is not null, branch to instruction at branchoffset (signed short constructed from unsigned bytes branchbyte1 << 8 + branchbyte2)
goto_w	c8	1100 1000	4: branchbyte1, branchbyte2, branchbyte3, branchbyte4	[no change]	goes to another instruction at branchoffset (signed int constructed from unsigned bytes branchbyte1 << 24 + branchbyte2 << 16 + branchbyte3 << 8 + branchbyte4)
jsr_w	c9	1100 1001	4: branchbyte1, branchbyte2, branchbyte3, branchbyte4	→ address	jump to subroutine at branchoffset (signed int constructed from unsigned bytes branchbyte1 << 24 + branchbyte2 << 16 + branchbyte3 << 8 + branchbyte4) and place the return address on the stack
breakpoint	ca	1100 1010			reserved for breakpoints in Java debuggers; should not appear in any class file
(no name)	cb-fd				these values are currently unassigned for opcodes and are reserved for future use
impdep1	fe	1111 1110			reserved for implementation-dependent operations within debuggers; should not appear in any class file
impdep2	ff
    }
}
