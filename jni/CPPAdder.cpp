#include <jni.h>
#include "Adder.h"

#ifdef __cplusplus
extern "C" {
#endif
/*
 * Class:     Adder
 * Method:    add
 * Signature: (II)I
 */
JNIEXPORT jint JNICALL Java_Adder_add(JNIEnv *env, jobject obj, jint x, jint y) {
	return x+y;
}

#ifdef __cplusplus
}
#endif
