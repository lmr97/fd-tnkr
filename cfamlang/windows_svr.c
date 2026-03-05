/*
    To compile, run: 

        gcc svr.c -o svr -lws2_32

    The linked library needs to be placed AFTER the output option (-o)
*/

#include <stdbool.h>
#include <errno.h>
#include <string.h>
#include <stdlib.h>
#include <stdio.h>
#include <winsock2.h>

int main(int argc, char** argv) {
    WSADATA wsad;
    int err = WSAStartup(MAKEWORD(2, 2), &wsad);

    if (err) {
        perror("could not get a hold of the Winsock2 DLL\n");
        int wsa_err = WSAGetLastError();
        printf("exit %d\n", wsa_err);
        return wsa_err;
    }

    SOCKET sockfd = socket(AF_INET, SOCK_STREAM, IPPROTO_TCP);
    if (sockfd == INVALID_SOCKET) {
        perror("Issue allocating socket.\n");
        int wsa_err = WSAGetLastError();
        printf("exit %d\n", wsa_err);
        WSACleanup();
        return wsa_err;
    }

    // Get the local host information (private IP, not loopback)
    struct hostent* localhost = gethostbyname("");
    char* localIP = inet_ntoa(*(struct in_addr *)*localhost->h_addr_list);

    printf("%s\n", localIP);
    // Set up the sockaddr structure
    struct sockaddr_in sock_ad;
    sock_ad.sin_family = AF_INET;
    sock_ad.sin_addr.s_addr = inet_addr(localIP);
    sock_ad.sin_port = htons(8080);

    int addrlen = sizeof(sock_ad);
    int max_clients = 1;
    
    err = bind(sockfd, (struct sockaddr*)&sock_ad, addrlen);
    if (err) {
        perror("Could not bind to address.\n");
        int wsa_err = WSAGetLastError();
        printf("exit %d\n", wsa_err);
        WSACleanup();
        return wsa_err;
    }

    err = listen(sockfd, max_clients);
    if (err) {
        perror("Could not listen on socket.\n");
        int wsa_err = WSAGetLastError();
        printf("exit %d\n", wsa_err);
        WSACleanup();
        return wsa_err;
    }

    struct pollfd fds[max_clients];
    fds[0].fd = sockfd;
    fds[0].events = POLLIN;
    fds[0].revents = 0;
    // for (int i = 0; i < max_clients; i++) {
    //     fds[i].fd
    // }
    
    const int buf_len = 200;
    printf("Server init complete! listening...\n");
    while (true) {
        // poll(fds, max_clients+1, -1);
        char buf[buf_len];
        printf("Waiting for next connection...\n");
        SOCKET incom_sock = accept(sockfd, NULL, NULL);
        int bytes_read = recv(incom_sock, buf, buf_len, 0);
        char* send_hi = "HTTP/1.1 200 OK\r\nContent-Length: 3\r\nContent-Type: text/plain\r\n\r\nhi!";
        send(incom_sock, send_hi, strlen(send_hi), 0);
        
        printf("%.*s", buf_len, buf);
        printf("(read %d bytes)\n", bytes_read);
        closesocket(incom_sock);
    }
    WSACleanup();
    return 0;
}