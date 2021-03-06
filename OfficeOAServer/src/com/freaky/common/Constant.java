package com.freaky.common;

/**
 * Created by Freaky on 2015/11/25.
 */
public class Constant {
    public static int b2i(byte[] b) {
        int value = 0;
        for (int i = 0; i < 4; i++) {
            int shift = (4 - 1 - i) * 8;
            value += (b[i] & 0x000000FF) << shift;
        }
        return value;    }
}
