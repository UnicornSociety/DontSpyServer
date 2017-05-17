<?php

class UserEntity implements JsonSerializable
{
    protected $id;
    protected $sender;
    protected $receiver;
    protected $message;
    protected $keyNumber;
    protected $timestamp;

    public function __construct(array $data)
    {
        // no id if we're creating
        if (isset($data['id'])) {
            $this->id = $data['id'];
        }
        $this->sender = $data['sender'];
        $this->receiver = $data['receiver'];
        $this->message = $data['message'];
        $this->keyNumber = $data['keyNumber'];
        $this->timestamp = $data['timestamp'];
    }

// saving data from post message routes

    public function saveId()
    {
        return $this->id;
    }
    public function saveTimestamp()
    {
        return $this->timestamp;
    }
    public function saveReceiver()
    {
        return $this->receiver;
    }
    public function saveSender()
    {
        return $this->sender;
    }
    public function saveKeyNumber()
    {
        return $this->keyNumber;
    }

// original

    public function getId()
    {
        return $this->id;
    }

    public function getFirstname()
    {
        return $this->firstname;
    }

    public function getSurname()
    {
        return $this->surname;
    }

    public function getEmail()
    {
        return $this->email; //email isn't e-Mail
    }

    public function jsonSerialize()
    {
        return [
            'id' => $this->getId(),
            'firstname' => $this->getFirstname(),
            'lastname' => $this->getLastname(),
            'lastname' => $this->getLastname(),
> $this->getSex()
        ];
    }
}
