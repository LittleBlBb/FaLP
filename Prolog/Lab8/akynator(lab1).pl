decl(ruby,0).
decl(c_sharp,0).
decl(python,0).
decl(c_plu_plus,0).
decl(f_sharp,1).
decl(prolog,1).
decl(c,0).
decl(asm,0).
%___
decl(java, 0).
decl(flutter, 0).
decl(dart, 0).

interpret(ruby,1).
interpret(python,1).
interpret(f_sharp,1).
interpret(prolog,1).
interpret(c_sharp,0).
interpret(c_plu_plus,0).
interpret(c,0).
interpret(asm,0).
%___
interpret(java, 0).
interpret(flutter, 0).
interpret(dart, 0).

oop(ruby,3).
oop(c_sharp,3).
oop(python,2).
oop(c_plu_plus,2).
oop(f_sharp,1).
oop(prolog,1).
oop(c,0).
oop(asm,0).
%___
oop(java, 3).
oop(flutter, 3).
oop(dart, 3).

cross(ruby,1).
cross(python,1).
cross(c_plu_plus,1).
cross(prolog,1).
cross(c,1).
cross(asm,1).
cross(c_sharp,0).
cross(f_sharp,0).
%___
cross(java, 1).
cross(flutter, 1).
cross(dart, 1).

visual(c_sharp,3).
visual(ruby,2).
visual(python,2).
visual(c_plu_plus,2).
visual(f_sharp,2).
visual(prolog,1).
visual(c,0).
visual(asm,0).
%___
visual(java, 2).
visual(flutter, 3).
visual(dart, 2).

mobile(c_sharp,0).
mobile(ruby,0).
mobile(python,0).
mobile(c_plu_plus,0).
mobile(f_sharp,0).
mobile(prolog,0).
mobile(c,0).
mobile(asm,0).
%___
mobile(java, 0).
mobile(flutter, 1).
mobile(dart, 1).
%___
coffee(c_sharp,0).
coffee(ruby,0).
coffee(python,0).
coffee(c_plu_plus,0).
coffee(f_sharp,0).
coffee(prolog,0).
coffee(c,0).
coffee(asm,0).
coffee(java, 1).

question1(X1):-	write("Is your language high level?"),nl,
				write("1. Yes"),nl,
				write("0. NO"),nl,
				read(X1).

question2(X2):-	write("Is your language declarative?"),nl,
				write("1. Yes"),nl,
				write("0. NO"),nl,
				read(X2).

question3(X3):-	write("Is your language interpret?"),nl,
				write("1. Yes"),nl,
				write("0. NO"),nl,
				read(X3).

question4(X4):-	write("Does your language support OOP?"),nl,
				write("3. It is OOP itself"),nl,
				write("2. yes"),nl,
				write("1. yes, but very hard"),nl,
				write("0. NO"),nl,
				read(X4).

question5(X5):-	write("Is your language crossplatformic?"),nl,
				write("1. Yes"),nl,
				write("0. NO"),nl,
				read(X5).

question6(X6):-	write("Does your language support visual interface for user?"),nl,
				write("3. It is visual itself"),nl,
				write("2. yes"),nl,
				write("1. yes, but very hard"),nl,
				write("0. NO"),nl,
				read(X6).

question7(X7):-	write("Is your language for mobile phones?"),nl,
				write("1. Yes"),nl,
				write("0. NO"),nl,
				read(X7).	

question8(X8):-	write("Is your language icon cup of coffee?"),nl,
				write("1. Yes"),nl,
				write("0. NO"),nl,
				read(X8).			



pr:-	question2(X2),question3(X3),question4(X4),
		question5(X5),question6(X6),question7(X7),
		decl(X,X2),interpret(X,X3),oop(X,X4),
		cross(X,X5),visual(X,X6),mobile(X,X7),
		write(X).

%task 5-6
%Здесь акинатор по студентам

%1
sub_group(abraamyan_KG, 1).
sub_group(dzamihov_ZV, 1).
sub_group(kazaryan_VG, 1).
sub_group(klichenko_DA, 1).
sub_group(kozlov_ED, 1).
sub_group(kochnev_VU, 1).
sub_group(krapotkin_MV, 1).
sub_group(sinkov_DV, 1).
sub_group(uskov_AA, 1).
sub_group(tsobehiya_DT, 1).
sub_group(shablin_ND, 1).
sub_group(mishenkina_VA, 1).
sub_group(krasnoslobodceva_EO, 1).
%2
sub_group(arutunyan_AK, 2).
sub_group(arutunyan_RG, 2).
sub_group(belokobilskiy_BV, 2).
sub_group(veber_ADA, 2).
sub_group(volkov_AA, 2).
sub_group(deryabin_AV, 2).
sub_group(dudo_SN, 2).
sub_group(duka_VA, 2).
sub_group(zhuravlev_DD, 2).
sub_group(logvina_AV, 2).
sub_group(markelov_VA, 2).
sub_group(osipov_VR, 2).
sub_group(pshenichnov_AA, 2).
sub_group(chertousov_VS, 2).

%1
slavyanin(abraamyan_KG, 0).
slavyanin(dzamihov_ZV, 0).
slavyanin(kazaryan_VG, 0).
slavyanin(klichenko_DA, 1).
slavyanin(kozlov_ED, 1).
slavyanin(kochnev_VU, 1).
slavyanin(krapotkin_MV, 1).
slavyanin(sinkov_DV, 1).
slavyanin(uskov_AA, 1).
slavyanin(tsobehiya_DT, 1).
slavyanin(shablin_ND, 1).
slavyanin(mishenkina_VA, 1).
slavyanin(krasnoslobodceva_EO, 1).
%2
slavyanin(arutunyan_AK, 0).
slavyanin(arutunyan_RG, 0).
slavyanin(belokobilskiy_BV, 1).
slavyanin(veber_ADA, 1).
slavyanin(volkov_AA, 1).
slavyanin(deryabin_AV, 1).
slavyanin(dudo_SN, 1).
slavyanin(duka_VA, 1).
slavyanin(zhuravlev_DD, 1).
slavyanin(logvina_AV, 1).
slavyanin(markelov_VA, 1).
slavyanin(osipov_VR, 1).
slavyanin(pshenichnov_AA, 0).
slavyanin(chertousov_VS, 1).

%1
sex(abraamyan_KG, 0).
sex(dzamihov_ZV, 1).
sex(kazaryan_VG, 0).
sex(klichenko_DA, 1).
sex(kozlov_ED, 1).
sex(kochnev_VU, 1).
sex(krapotkin_MV, 1).
sex(sinkov_DV, 1).
sex(uskov_AA, 1).
sex(tsobehiya_DT, 1).
sex(shablin_ND, 1).
sex(mishenkina_VA, 0).
sex(krasnoslobodceva_EO, 0).
%2
sex(arutunyan_AK, 1).
sex(arutunyan_RG, 1).
sex(belokobilskiy_BV, 1).
sex(veber_ADA, 1).
sex(volkov_AA, 1).
sex(deryabin_AV, 1).
sex(dudo_SN, 1).
sex(duka_VA, 1).
sex(zhuravlev_DD, 1).
sex(logvina_AV, 0).
sex(markelov_VA, 1).
sex(osipov_VR, 1).
sex(pshenichnov_AA, 1).
sex(chertousov_VS, 1).

%1
long_hair(abraamyan_KG, 3).
long_hair(dzamihov_ZV, 1).
long_hair(kazaryan_VG, 3).
long_hair(klichenko_DA, 1).
long_hair(kozlov_ED, 0).
long_hair(kochnev_VU, 0).
long_hair(krapotkin_MV, 1).
long_hair(sinkov_DV, 3).
long_hair(uskov_AA, 2).
long_hair(tsobehiya_DT, 1).
long_hair(shablin_ND, 1).
long_hair(mishenkina_VA, 2).
long_hair(krasnoslobodceva_EO, 3).
%2
long_hair(arutunyan_AK, 1).
long_hair(arutunyan_RG, 0).
long_hair(belokobilskiy_BV, 1).
long_hair(veber_ADA, 3).
long_hair(volkov_AA, 3).
long_hair(deryabin_AV, 1).
long_hair(dudo_SN, 1).
long_hair(duka_VA, 0).
long_hair(zhuravlev_DD, 2).
long_hair(logvina_AV, 3).
long_hair(markelov_VA, 2).
long_hair(osipov_VR, 2).
long_hair(pshenichnov_AA, 1).
long_hair(chertousov_VS, 3).

%1
hair_color(abraamyan_KG, 0).
hair_color(dzamihov_ZV, 1).
hair_color(kazaryan_VG, 0).
hair_color(klichenko_DA, 1).
hair_color(kozlov_ED, 1).
hair_color(kochnev_VU, 0).
hair_color(krapotkin_MV, 0).
hair_color(sinkov_DV, 0).
hair_color(uskov_AA, 2).
hair_color(tsobehiya_DT, 0).
hair_color(shablin_ND, 1).
hair_color(mishenkina_VA, 1).
hair_color(krasnoslobodceva_EO, 2).
%2
hair_color(arutunyan_AK, 0).
hair_color(arutunyan_RG, 0).
hair_color(belokobilskiy_BV, 1).
hair_color(veber_ADA, 2).
hair_color(volkov_AA, 1).
hair_color(deryabin_AV, 1).
hair_color(dudo_SN, 1).
hair_color(duka_VA, 0).
hair_color(zhuravlev_DD, 1).
hair_color(logvina_AV, 1).
hair_color(markelov_VA, 2).
hair_color(osipov_VR, 1).
hair_color(pshenichnov_AA, 0).
hair_color(chertousov_VS, 2).

%1
good_student(abraamyan_KG, 2).
good_student(dzamihov_ZV, 2).
good_student(kazaryan_VG, 2).
good_student(klichenko_DA, 2).
good_student(kozlov_ED, 2).
good_student(kochnev_VU, 3).
good_student(krapotkin_MV, 0).
good_student(sinkov_DV, 2).
good_student(uskov_AA, 1).
good_student(tsobehiya_DT, 2).
good_student(shablin_ND, 0).
good_student(mishenkina_VA, 1).
good_student(krasnoslobodceva_EO, 2).
%2
good_student(arutunyan_AK, 2).
good_student(arutunyan_RG, 1).
good_student(belokobilskiy_BV, 3).
good_student(veber_ADA, 0).
good_student(volkov_AA, 2).
good_student(deryabin_AV, 0).
good_student(dudo_SN, 1).
good_student(duka_VA, 2).
good_student(zhuravlev_DD, 2).
good_student(logvina_AV, 2).
good_student(markelov_VA, 1).
good_student(osipov_VR, 3).
good_student(pshenichnov_AA, 3).
good_student(chertousov_VS, 1).

ques1(A1):-	write("What subgroup is your student in?"),nl,
				write("1. 39.1"),nl,
				write("2. 39.2"),nl,
				read(A1).

ques2(A2):-	write("Is your student looks like slavyanin?"),nl,
				write("1. Yes"),nl,
				write("0. No"),nl,
				read(A2).

ques3(A3):-	write("Is your student man?"),nl,
				write("1. Yes"),nl,
				write("0. No"),nl,
				read(A3).

ques4(A4):-	write("How long is your student's hair?"),nl,
				write("3. Very long"),nl,
				write("2. Long"),nl,
				write("1. Short"),nl,
				write("0. Very short"),nl,
				read(A4).

ques5(A5):-	write("What color hair does your student have?"),nl,
				write("0. Dark"),nl,
				write("1. Between dark and light"),nl,
				write("2. Light"),nl,
				read(A5).

ques6(A6):-	write("How is your student doing at university?"),nl,
				write("3. Very good"),nl,
				write("2. Good"),nl,
				write("1. Bad"),nl,
				write("0. Very bad"),nl,
				read(A6).

prTask:- ques1(A1), ques2(A2), ques3(A3), ques4(A4), ques5(A5), ques6(A6),
		 sub_group(X, A1), slavyanin(X, A2), sex(X, A3), long_hair(X, A4),
		 hair_color(X, A5), good_student(X, A6),
		 write(X).
