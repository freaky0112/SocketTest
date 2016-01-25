package com.freaky;

import java.net.Socket;

public class Main {

    public static void main(String[] args) {
        // write your code here
        //int listenPort = Integer.parseInt(System.console().readLine());
        int listenPort = 8081;
        Server server = new Server(listenPort);
        server.init();
    }
}
