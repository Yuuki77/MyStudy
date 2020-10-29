// SP=256
// call Sys.init
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
//push constant 0
@0
D = A
@256
M = D
@257
D = A
@R0
M = D
//pop local 0
@0
D = A
@300
M = D
@256
D = A
@R0
M = D
//label LOOP_START
(LOOP_START)
//push argument 0
@0
D = A
@256
M = D
@257
D = A
@R0
M = D
//push local 0
@0
D = A
@257
M = D
@258
D = A
@R0
M = D
//add
@0
D = A
@256
M = D
@257
D = A
@R0
M = D
//pop local 0
@0
D = A
@300
M = D
@256
D = A
@R0
M = D
//push argument 0
@0
D = A
@256
M = D
@257
D = A
@R0
M = D
//push constant 1
@1
D = A
@257
M = D
@258
D = A
@R0
M = D
//sub
@1
D = -A
@256
M = D
@257
D = A
@R0
M = D
//pop argument 0
@1
D = -A
@400
M = D
@256
D = A
@R0
M = D
//push argument 0
@1
D = -A
@256
M = D
@257
D = A
@R0
M = D
//if-goto LOOP_START
@-1
D = A
@LOOP_START
D;JGT
//push local 0
@0
D = A
@256
M = D
@257
D = A
@R0
M = D
