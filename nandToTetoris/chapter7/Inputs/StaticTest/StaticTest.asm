@300
D = A
@R1
M = D
@400
D = A
@R2
M = D
@3000
D = A
@R3
M = D
@3010
D = A
@R4
M = D
//push constant 111
@111
D = A
@256
M = D
@257
D = A
@R0
M = D
//push constant 333
@333
D = A
@257
M = D
@258
D = A
@R0
M = D
//push constant 888
@888
D = A
@258
M = D
@259
D = A
@R0
M = D
//pop static 8
@StaticTest.888
D = M
@258
D = A
@R0
M = D
//pop static 3
@StaticTest.333
D = M
@257
D = A
@R0
M = D
//pop static 1
@StaticTest.111
D = M
@256
D = A
@R0
M = D
//push static 3
@333
D = A
@256
M = D
@257
D = A
@R0
M = D
//push static 1
@111
D = A
@257
M = D
@258
D = A
@R0
M = D
//sub
@222
D = A
@256
M = D
@257
D = A
@R0
M = D
//push static 8
@888
D = A
@257
M = D
@258
D = A
@R0
M = D
//add
@1110
D = A
@256
M = D
@257
D = A
@R0
M = D
