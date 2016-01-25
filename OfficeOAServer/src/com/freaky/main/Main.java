package com.freaky.main;

/**
 * Created by Freaky on 2015/11/25.
 */
public class Main {

    public static void main(String[] args) throws Exception {
        int port=7788;
        new Server(port,"G://TEST//").start();
    }
}